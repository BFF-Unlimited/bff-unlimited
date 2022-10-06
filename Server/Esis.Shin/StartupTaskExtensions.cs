namespace Esis.Shin
{
    internal static class StartupTaskExtensions
    {
        private static readonly StartupTaskContext SharedContext = new StartupTaskContext();

        private static IServiceCollection AddStartupTasks(this IServiceCollection services)
        {
            // Add the singleton StartupTaskContext only once
            if (services.Any(x => x.ServiceType != typeof(StartupTaskContext)))
            {
                services.AddSingleton(SharedContext);
                services.AddTransient<IStartupTaskContext>(factory => factory.GetRequiredService<StartupTaskContext>());
            }

            return services;
        }

        public static IServiceCollection AddStartupTask<T>(this IServiceCollection services)
            where T : class, IStartupTask
        {
            SharedContext.RegisterTask();
            return services
                .AddStartupTasks()
                .AddHostedService<T>();
        }
    }
}