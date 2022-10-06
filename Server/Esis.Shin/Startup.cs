using Autofac.Core;
using Esis.Shin.Core.Framework;
using Esis.Shin.Core.Framework.Handlers;
using Esis.Shin.Core.Framework.Logging;
using Esis.Shin.Core.Framework.RequestErrorHandling;
using Esis.Shin.Services.Administrations.DataAccess.Mysql;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Ninject;
using Serilog;
using System.Text.Json.Serialization;

namespace Esis.Shin
{
    public class Startup
    {
        private readonly IKernel _kernel;

        public IConfiguration Configuration { get; }

        public IHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
            _kernel = SetupDependecyInjection();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddEndpointsApiExplorer();
            services.AddIamAuthentication(Configuration, Environment.IsDevelopment());

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
            app.UseSerilogRequestLogging();
            SetupDevelopmentEnviroment(app, env);
            SetupProductionEnviroment(app, env);
            
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseBlockPentestingMiddleware();
            app.UseStaticFiles();
            app.UseRouting();
            
            app.UseIamAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    "default", "{controller=Home}/{action=Index}/{id?}");
            });

            if(env.IsDevelopment())
            {
                app.UseSpa(options =>
                {
                    options.UseProxyToSpaDevelopmentServer(Configuration["FrontEnd"]);
                });
            }

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

            app.UseHsts();
        }

        private static void SetupDevelopmentEnviroment(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if(!env.IsDevelopment())
                return;

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }
    }
}
