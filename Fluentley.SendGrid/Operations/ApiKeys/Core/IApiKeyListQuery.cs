using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.ApiKeys.Models;

namespace Fluentley.SendGrid.Operations.ApiKeys.Core
{
    public interface IApiKeyListQuery : IListMemoryFilterQuery<IApiKeyListQuery, ApiKey>,
        IContextQuery<IApiKeyListQuery>
    {
        IApiKeyListQuery LimitResults(int value);
    }
}