// Copyright ReflexSystems

using Bff.Domain.Model.Core.Framework;
using Ninject;
using System.Reflection;

namespace Bff.WebApi
{
    public interface IStartupTaskContext
    {
        Task WaitForCompletion();
    }

    internal sealed class StartupTaskContext : IStartupTaskContext
    {
        private readonly TaskCompletionSource<bool> startupComplete = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        private int outstandingTaskCount;

        public bool IsComplete => this.outstandingTaskCount == 0 && !this.HasError;
        public bool HasError { get; private set; }

        public void RegisterTask() =>
            Interlocked.Increment(ref this.outstandingTaskCount);

        public void CompleteTask()
        {
            var count = Interlocked.Decrement(ref this.outstandingTaskCount);
            if (count == 0)
                this.startupComplete.TrySetResult(true);
        }

        public Task WaitForCompletion() => this.startupComplete.Task;

        public void FailTask(Exception ex)
        {
            this.HasError = true;

            this.startupComplete.TrySetException(ex);
        }
    }

    internal interface IStartupTask : IHostedService
    {
    }

    internal abstract class StartupTask : BackgroundService, IStartupTask
    {
        private readonly StartupTaskContext startupTaskContext;

        protected StartupTask(StartupTaskContext startupTaskContext)
        {
            this.startupTaskContext = startupTaskContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                await this.DoStartAsync(stoppingToken);

                this.startupTaskContext.CompleteTask();
            }
            catch (Exception ex)
            {
                this.startupTaskContext.FailTask(ex);

                throw;
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken) =>
             this.DoStopAsync(cancellationToken);

        protected virtual Task DoStartAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        protected virtual Task DoStopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }

    internal sealed class StartApplicationServerTask : StartupTask
    {
        private readonly IKernel kernel;
        private readonly ILoggerFactory loggerFactory;
        private readonly IServiceProvider serviceProvider;

        public StartApplicationServerTask(
            IServiceProvider serviceProvider,
            ILoggerFactory loggerFactory, 
            IKernel kernel, 
            StartupTaskContext startupTaskContext) : base (startupTaskContext)
        {
            this.serviceProvider = serviceProvider;
            this.loggerFactory = loggerFactory;
            this.kernel = kernel;
        }

        protected override Task DoStartAsync(CancellationToken cancellationToken)
        {
            var logger = this.loggerFactory.CreateLogger<StartApplicationServerTask>();
            logger.LogInformation("Starting application server");

            this.ConfigureKernel();

            this.LoadModules();

            return Task.CompletedTask;
        }

        private void LoadModules()
        {
            Assembly applicationServerAssembly = Assembly.GetExecutingAssembly() ?? throw new ApplicationException();
            var executingAssemblyFullPath = new Uri(applicationServerAssembly.GetName().CodeBase!).LocalPath;
            var folderPath = Path.GetDirectoryName(executingAssemblyFullPath);

            var di = new DirectoryInfo(folderPath!);
            var files = di.GetFiles("*.Services.*.dll");

            var modules = files
                .Select(f => Assembly.LoadFrom(f.FullName)
                    .GetExportedTypes()
                    .FirstOrDefault(type => !type.IsAbstract && type.IsSubclassOf(typeof(ModuleComposite))))
                .Where(a => a != null)
                .Select(moduleType => (ModuleComposite)this.kernel.Get(moduleType))
                .ToList();


            modules.ForEach(module => module.InitializeNinject(this.kernel));
        }

        private void ConfigureKernel()
        {
            // Make ASP .Net Core classes available to the ninject DI
            this.kernel.Bind<IServiceProvider>().ToConstant(this.serviceProvider);
            this.kernel.Bind<ILoggerFactory>().ToMethod(_ => _.Kernel.Get<IServiceProvider>().GetRequiredService<ILoggerFactory>());
            this.kernel.Bind<IHttpContextAccessor>().ToMethod(_ => _.Kernel.Get<IServiceProvider>().GetRequiredService<IHttpContextAccessor>());
            this.kernel.Bind<IHttpClientFactory>().ToMethod(_ => _.Kernel.Get<IServiceProvider>().GetRequiredService<IHttpClientFactory>());
            this.kernel.Bind<IRovictLogger>().ToMethod(_ => _.Kernel.Get<IServiceProvider>().GetRequiredService<IRovictLogger>());
            this.kernel.Bind<IConfiguration>().ToMethod(x => x.Kernel.Get<IServiceProvider>().GetRequiredService<IConfiguration>());
        }
    }
}