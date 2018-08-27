using System;
using Fluentley.QueryBuilder.Options;

namespace Fluentley.SendGrid.Common.Queries
{
    public interface IListMemoryFilterQuery<out T, TModel>
    {
        T UseInMemoryQuery(Action<IQueryOption<TModel>> option);
    }
}