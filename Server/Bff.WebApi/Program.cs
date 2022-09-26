using Bff.Core.Framework;
using Bff.Core.Framework.Handlers;
using Bff.Core.Framework.Logging;
using Bff.Core.Framework.RequestErrorHandling;
using Bff.WebApi.Services.Administrations.DataAccess.Mysql;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Ninject;

namespace Bff.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
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
            var kernel = new StandardKernel();

            builder.Services.AddSingleton<IKernel>(kernel);
            builder.Services.AddSingleton<IRovictLogger>(x => new DefaultApplicationServerLogger(new LoggerFactory()));
            builder.Services.AddSingleton<IHandlerFactory>(x => new MagicNinjectFactory(kernel));
            builder.Services.AddSingleton<IOperationResultFactory>(new OperationResultFactory());
            builder.Services.AddSingleton<IExceptionHandler>(new DefaultExceptionHandler(new OperationResultFactory()));

            builder.Services
                .AddSignalR()
                .AddNewtonsoftJsonProtocol();

            builder.Services.Replace(new ServiceDescriptor(
                typeof(IHubActivator<>),
                typeof(NinjectHubActivator<>),
                ServiceLifetime.Scoped));

            builder.Services.AddStartupTask<StartApplicationServerTask>();

            builder.Services.AddDbContext<AdministrationContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.UseBlockPentestingMiddleware();

            using(var scope = app.Services.CreateScope())
            {
                var administrationContext = scope.ServiceProvider.GetRequiredService<AdministrationContext>();
                administrationContext.Database.Migrate();
            }

            app.Run();
        }
    }
}