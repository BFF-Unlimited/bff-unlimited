namespace Bff.Domain.Model.Core.Framework
{
    public interface IQueryHandler<TQuery> where TQuery : class
    {
        object Execute(TQuery query);
    }
}
