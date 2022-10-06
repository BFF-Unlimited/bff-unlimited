using Serilog;

namespace Esis.Shin
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
