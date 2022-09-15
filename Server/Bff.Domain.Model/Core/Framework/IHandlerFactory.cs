using Ninject;

namespace Bff.Domain.Model.Core.Framework
{
    public interface IHandlerFactory
    {
        IKernel Kernel { get; }

        IQueryHandler<TQuery> GetQueryHandler<TQuery>() where TQuery : class;

    }
}
