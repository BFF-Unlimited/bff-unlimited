namespace Bff.Core.Framework
{
    public interface IAsyncQueryHandler<in TQuery> : IHandler
        where TQuery : class
    {
        Task<object> ExecuteAsync(TQuery query);
    }
}
