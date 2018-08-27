using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.ApiKeys.Models;

namespace Fluentley.SendGrid.Operations.ApiKeys.Core
{
    public interface ICreateApiKeyCommand : IContextQuery<ICreateApiKeyCommand>

    {
        ICreateApiKeyCommand ByModel(ApiKey apiKey);
        ICreateApiKeyCommand Initiate(string name, params Scope[] scopes);
        ICreateApiKeyCommand AddScope(params Scope[] scopes);
    }
}