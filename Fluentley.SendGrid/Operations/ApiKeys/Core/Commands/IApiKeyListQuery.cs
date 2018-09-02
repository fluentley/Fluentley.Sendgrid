using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.ApiKeys.Models;

namespace Fluentley.SendGrid.Operations.ApiKeys.Core.Commands
{
    public interface IApiKeyListQuery : IListMemoryFilterQuery<IApiKeyListQuery, ApiKey>,
        IContextQuery<IApiKeyListQuery>
    {
        /// <summary>
        /// Limits the results.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        IApiKeyListQuery LimitResults(int value);
  
    