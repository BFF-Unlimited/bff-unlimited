using Serilog;

namespace Bff.WebApi
{
    public static class LoggerConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddLogging(loggingBuilder =>
                loggingBuilder.AddSerilog(dispose: true));

        }
    }
}
