using Autofac.Core;
using Bff.Core.Framework;
using Bff.Core.Framework.Handlers;
using Bff.Core.Framework.Logging;
using Bff.Core.Framework.RequestErrorHandling;
using Bff.WebApi.Services.Administrations.DataAccess.Mysql;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Ninject;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Bff.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = SetupServices(args);

            var app = builder.Build();

            SetupDevelopmentEnviroment(app);
            SetupProductionEnviroment(app);

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.UseBlockPentestingMiddleware();
			
			SetupDatabase(app);
			
            app.Run();
        }

		private static void SetupDatabase(WebApplication app)
		{
            using(var scope = app.Services.CreateScope())
            {
                var administrationContext = scope.ServiceProvider.GetRequiredService<AdministrationContext>();
                administrationContext.Database.Migrate();
            }
		}
		
        private static WebApplicationBuilder SetupServices(string[] args)
        {
            var kernel = SetupDependecyInjection();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.UseAuthentication();

            SwaggerConfig.Configure(builder.Services);
            LoggerConfig.Configure(builder.Services);

            builder.Services.AddHttpClient();

            SetupWebApiDepencenyServices(builder, kernel);
            builder.Services.AddControllers().AddJsonOptions(x =>
            {
                // serialize enums as strings in api responses (e.g. Role)
                x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            builder.Services
                .AddSignalR()
                .AddNewtonsoftJsonProtocol();

            builder.Services.Replace(new ServiceDescriptor(
                typeof(IHubActivator<>),
                typeof(NinjectHubActivator<>),
                ServiceLifetime.Scoped));

            builder.Services.AddStartupTask<StartApplicationServerTask>();
			
			builder.Services.AddDbContext<AdministrationContext>();
			
            return builder;
        }

        private static void SetupProductionEnviroment(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
                return; 

            // Setup Cors for some private adressen
            app.UseCors(builder =>
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                       );
            app.UseHsts();
        }

        private static void SetupDevelopmentEnviroment(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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

        private static void SetupWebApiDepencenyServices(WebApplicationBuilder builder, IKernel kernel)
        {
            builder.Services.AddSingleton(kernel);
            builder.Services.AddSingleton(x => kernel.Get<IRovictLogger>());
            builder.Services.AddSingleton(x => kernel.Get<IHandlerFactory>());
            builder.Services.AddSingleton(x => kernel.Get<IOperationResultFactory>());
            builder.Services.AddSingleton(x => kernel.Get<IExceptionHandler>());
            builder.Services.AddSingleton(x => kernel.Get<IAdministrationContext>());
        }

        private static StandardKernel SetupDependecyInjection()
        {
            return new StandardKernel();
        }
    }
}