﻿namespace Bff.Domain.Model.Core.Framework
{
    public interface IQueryHandler<TQuery> : IHandler where TQuery : class
    {
        object Execute(TQuery query);
    }
}
