using Bff.Core.Framework;
using Bff.Core.Framework.Handlers;
using Bff.Core.Framework.Logging;
using Bff.Core.Framework.RequestErrorHandling;
using Bff.WebApi.Services.Administrations.DataAccess.Mysql;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Ninject;
using System.Text.Json.Serialization;

namespace Bff.WebApi
{
    public class Startup
    {
        private readonly IKernel _kernel;

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _kernel = SetupDependecyInjection();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            SwaggerConfig.Configure(services);
            LoggerConfig.Configure(services);

            services.AddHttpClient();

            SetupWebApiDepencenyServices(services, _kernel);
            services.AddControllers().AddJsonOptions(x =>
            {
                // serialize enums as strings in api responses (e.g. Role)
                x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            
            services.Replace(new ServiceDescriptor(
                             typeof(IHubActivator<>),
                             typeof(NinjectHubActivator<>),
                             ServiceLifetime.Scoped));

            services.AddStartupTask<StartApplicationServerTask>();
            services.AddDbContext<AdministrationContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            SetupDevelopmentEnviroment(app, env);
            SetupProductionEnviroment(app, env);

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseBlockPentestingMiddleware();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    "default", "{controller=Home}/{action=Index}/{id?}");
            });
            SetupDatabase(app);
        }

        private static void SetupWebApiDepencenyServices(IServiceCollection services, IKernel kernel)
        {
            services.AddSingleton(kernel);
            services.AddSingleton(x => kernel.Get<IRovictLogger>());
            services.AddSingleton(x => kernel.Get<IHandlerFactory>());
            services.AddSingleton(x => kernel.Get<IOperationResultFactory>());
            services.AddSingleton(x => kernel.Get<IExceptionHandler>());
            services.AddSingleton(x => kernel.Get<IAdministrationContext>());
        }

        private static StandardKernel SetupDependecyInjection()
        {
            return new StandardKernel();
        }

        private static void SetupDatabase(IApplicationBuilder app)
        {
            using(var scope = app.ApplicationServices.CreateScope())
            {
                var administrationContext = scope.ServiceProvider.GetRequiredService<AdministrationContext>();
                administrationContext.Database.Migrate();
            }
        }

        private static void SetupProductionEnviroment(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
                return;

            // Setup Cors for some private adressen
            app.UseCors(builder =>
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                       );
            app.UseHsts();
        }

        private static void SetupDevelopmentEnviroment(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if(!env.IsDevelopment())
                return;

            // Disable Cors for development to make live simpler
            app.UseCors(builder =>
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                        );

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }
    }
}
