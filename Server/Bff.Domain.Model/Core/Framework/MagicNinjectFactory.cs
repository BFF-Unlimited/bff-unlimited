using Ninject;

namespace Bff.Domain.Model.Core.Framework
{
    public sealed class MagicNinjectFactory : IHandlerFactory
    {
        public MagicNinjectFactory(IKernel kernel)
        {
            this.Kernel = kernel;
        }

        public IKernel Kernel { get; }

        //public ICommandHandler<TCommand> GetCommandHandler<TCommand>() where TCommand : class => this.Context.Resolve<ICommandHandler<TCommand>>();

        public IQueryHandler<TQuery> GetQueryHandler<TQuery>() where TQuery : class => this.Kernel.Get<IQueryHandler<TQuery>>();

        //public IAsyncCommandHandler<TCommand> GetAsyncCommandHandler<TCommand>() where TCommand : class => this.Context.Resolve<IAsyncCommandHandler<TCommand>>();

        //public IAsyncQueryHandler<TQuery> GetAsyncQueryHandler<TQuery>() where TQuery : class => this.Context.Resolve<IAsyncQueryHandler<TQuery>>();
    }
}
