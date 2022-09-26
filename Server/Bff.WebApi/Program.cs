using Bff.Core.Framework;
using Bff.Core.Framework.Handlers;
using Bff.Core.Framework.Logging;
using Bff.Core.Framework.RequestErrorHandling;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Ninject;

namespace Bff.WebApi
{
    public static class Program
    {
        private static WebApplication? _app;

        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            _ = builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            _ = builder.Services.AddEndpointsApiExplorer();
            builder.UseAuthentication();

            SwaggerConfig.Configure(builder.Services);
            LoggerConfig.Configure(builder.Services);

            _ = builder.Services.AddHttpClient();
            var kernel = new StandardKernel();

            _ = builder.Services.AddSingleton<IKernel>(kernel);
            _ = builder.Services.AddSingleton<IRovictLogger>(x => new DefaultApplicationServerLogger(new LoggerFactory()));
            _ = builder.Services.AddSingleton<IHandlerFactory>(x => new MagicNinjectFactory(kernel));
            _ = builder.Services.AddSingleton<IOperationResultFactory>(new OperationResultFactory());
            _ = builder.Services.AddSingleton<IExceptionHandler>(new DefaultExceptionHandler(new OperationResultFactory()));

            _ = builder.Services
                .AddSignalR()
                .AddNewtonsoftJsonProtocol();

            _ = builder.Services.Replace(new ServiceDescriptor(
                typeof(IHubActivator<>),
                typeof(NinjectHubActivator<>),
                ServiceLifetime.Scoped));

            _ = builder.Services.AddStartupTask<StartApplicationServerTask>();

            _app = builder.Build();

            // Configure the HTTP request pipeline.
            if(_app.Environment.IsDevelopment())
            {
                _ = _app.UseSwagger();
                _ = _app.UseSwaggerUI();
                _ = _app.UseDeveloperExceptionPage();
            }

            _ = _app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
            });

            _ = _app.UseHttpsRedirection();

            _ = _app.UseAuthentication();
            _ = _app.UseAuthorization();

            _ = _app.MapControllers();
            _ = _app.UseBlockPentestingMiddleware();

            await _app.RunAsync();
        }

        public static string ServerUrl => "https://127.0.0.1:5101";
    }
}