namespace Bff.Core.Framework.Handlers
{
    public interface IQueryHandler<TQuery> : IHandler where TQuery : class
    {
        object Execute(TQuery query);
    }
}
