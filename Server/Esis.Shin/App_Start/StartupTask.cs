namespace Esis.Shin
{
    internal abstract class StartupTask : BackgroundService, IStartupTask
    {
        private readonly StartupTaskContext _startupTaskContext;

        protected StartupTask(StartupTaskContext startupTaskContext)
        {
            _startupTaskContext = startupTaskContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                await DoStartAsync(stoppingToken);

                _startupTaskContext.CompleteTask();
            }
            catch (Exception ex)
            {
                _startupTaskContext.FailTask(ex);

                throw;
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken) => DoStopAsync(cancellationToken);

        protected virtual Task DoStartAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        protected virtual Task DoStopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}