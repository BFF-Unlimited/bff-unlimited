using Ninject;

namespace Bff.Core.Framework.Handlers
{
    public interface IHandlerFactory
    {
        IKernel Kernel { get; }

        ICommandHandler<TCommand> GetCommandHandler<TCommand>() where TCommand : class;

        IQueryHandler<TQuery> GetQueryHandler<TQuery>() where TQuery : class;

        IAsyncCommandHandler<TCommand> GetAsyncCommandHandler<TCommand>() where TCommand : class;

        IAsyncQueryHandler<TQuery> GetAsyncQueryHandler<TQuery>() where TQuery : class;

    }
}
