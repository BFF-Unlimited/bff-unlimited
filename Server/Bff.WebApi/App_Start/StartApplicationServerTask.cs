using Bff.Core.Framework;
using Bff.Core.Framework.Handlers;
using Bff.Core.Framework.Logging;
using Bff.Core.Framework.RequestErrorHandling;
using Bff.WebApi.Services.Administrations.DataAccess.Mysql;
using Ninject;
using System.Reflection;

namespace Bff.WebApi
{
    internal sealed class StartApplicationServerTask : StartupTask
    {
        private readonly IKernel _kernel;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IServiceProvider _serviceProvider;

        public StartApplicationServerTask(
            IServiceProvider serviceProvider,
            ILoggerFactory loggerFactory, 
            IKernel kernel, 
            StartupTaskContext startupTaskContext) : base (startupTaskContext)
        {
            _serviceProvider = serviceProvider;
            _loggerFactory = loggerFactory;
            _kernel = kernel;
        }

        protected override Task DoStartAsync(CancellationToken cancellationToken)
        {
            var logger = _loggerFactory.CreateLogger<StartApplicationServerTask>();
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
                .Select(moduleType => (ModuleComposite)_kernel.Get(moduleType))
                .ToList();

            modules.ForEach(module => module.InitializeNinject(_kernel));
        }

        private void ConfigureKernel()
        {
            // Make ASP .Net Core classes available to the ninject DI
            _kernel.Bind<IServiceProvider>().ToConstant(_serviceProvider);
            _kernel.Bind<ILoggerFactory>().ToMethod(x => x.Kernel.Get<IServiceProvider>().GetRequiredService<ILoggerFactory>()).InSingletonScope();
            _kernel.Bind<IHttpContextAccessor>().ToMethod(x => x.Kernel.Get<IServiceProvider>().GetRequiredService<IHttpContextAccessor>());
            _kernel.Bind<IHttpClientFactory>().ToMethod(x => x.Kernel.Get<IServiceProvider>().GetRequiredService<IHttpClientFactory>());
            _kernel.Bind<IConfiguration>().ToMethod(x => x.Kernel.Get<IServiceProvider>().GetRequiredService<IConfiguration>());
            _kernel.Bind<IRovictLogger>().To<DefaultApplicationServerLogger>().InSingletonScope();
            _kernel.Bind<IHandlerFactory>().To<MagicNinjectFactory>().InSingletonScope();
            _kernel.Bind<IOperationResultFactory>().To<OperationResultFactory>().InSingletonScope();
            _kernel.Bind<IExceptionHandler>().To<DefaultExceptionHandler>().InSingletonScope();
            _kernel.Bind<IAdministrationContext>().To<AdministrationContext>().InSingletonScope();
        }
    }
}