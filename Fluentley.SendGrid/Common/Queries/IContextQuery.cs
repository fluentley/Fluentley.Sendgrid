using System;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;

namespace Fluentley.SendGrid.Common.Queries
{
    public interface IContextQuery<out T>
    {
        T UseContextOption(Action<IContextOption> option);
    }

    public interface IListMemoryFilterQuery<out T, TModel>
    {
        T UseInMemoryQuery(Action<IQueryOption<TModel>> option);
    }
}