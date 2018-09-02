using System;
using Fluentley.QueryBuilder.Options;

namespace Fluentley.SendGrid.Common.Queries
{
    public interface IListMemoryFilterQuery<out T, TModel>
    {
        /// <summary>
        /// In Memory Query, this will run after the execution.
        /// </summary>
        /// <param name="option">Query option</param>
        /// <returns></returns>
        T UseInMemoryQuery(Action<IQueryOption<TModel>> option);
    }
}