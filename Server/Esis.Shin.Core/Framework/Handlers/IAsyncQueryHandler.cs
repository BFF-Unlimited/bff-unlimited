namespace Esis.Shin.Core.Framework.Handlers
{
    public interface IAsyncQueryHandler<in TQuery> : IHandler
        where TQuery : class
    {
        Task<object> ExecuteAsync(TQuery query);
    }
}
