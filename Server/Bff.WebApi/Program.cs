using Serilog.Events;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using Microsoft.AspNetCore;

namespace Bff.WebApi
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await host.RunAsync();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) 
        {
            return WebHost
                .CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog
                ((ctx, lc) =>
                    lc.WriteTo
                        .Console(
                            outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}",
                            theme: AnsiConsoleTheme.Literate
                        )
                        .Enrich.FromLogContext()
                        .ReadFrom.Configuration(ctx.Configuration)
                );
        }
    }
}