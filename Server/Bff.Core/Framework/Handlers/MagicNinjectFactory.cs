using Ninject;

namespace Bff.Core.Framework.Handlers
{
    public sealed class MagicNinjectFactory : IHandlerFactory
    {
        public MagicNinjectFactory(IKernel kernel)
        {
            Kernel = kernel;
        }

        public IKernel Kernel { get; }

        public ICommandHandler<TCommand> GetCommandHandler<TCommand>() where TCommand : class => Kernel.Get<ICommandHandler<TCommand>>();

        public IQueryHandler<TQuery> GetQueryHandler<TQuery>() where TQuery : class => Kernel.Get<IQueryHandler<TQuery>>();

        public IAsyncCommandHandler<TCommand> GetAsyncCommandHandler<TCommand>() where TCommand : class => Kernel.Get<IAsyncCommandHandler<TCommand>>();

        public IAsyncQueryHandler<TQuery> GetAsyncQueryHandler<TQuery>() where TQuery : class => Kernel.Get<IAsyncQueryHandler<TQuery>>();
    }
}
