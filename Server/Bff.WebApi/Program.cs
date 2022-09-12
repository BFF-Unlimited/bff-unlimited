using Autofac.Core;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Bff.WebApi
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
             
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.UseAuthentication();

            SwaggerConfig.Configure(builder.Services);
            LoggerConfig.Configure(builder.Services);

            builder.Services.AddHttpClient();

            builder.Services
                .AddSignalR()
                .AddNewtonsoftJsonProtocol();

            builder.Services.Replace(new ServiceDescriptor(
                typeof(IHubActivator<>),
                typeof(NinjectHubActivator<>),
                ServiceLifetime.Scoped));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.UseBlockPentestingMiddleware();
/*
 * 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions { Predicate = check => check.Tags.Contains("ready"), ResponseWriter = WriteResponse });
                endpoints.MapHealthChecks("/health/live", new HealthCheckOptions { Predicate = check => check.Tags.Contains("live"), ResponseWriter = WriteResponse });

                // asp.net registrations for the signalr hubs. Don't forget to register the IHubContext<T> in ninject also (see Bootstrap)
                endpoints.MapHub<PrinterServiceHub>("/notifications/printerservice");
                endpoints.MapHub<NotificationsHub>("/notifications/common");
                endpoints.MapHub<ManagementNotificationsHub>("/notifications/management");

                endpoints.MapControllers();
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });*/

            app.Run();
        }
    }
}