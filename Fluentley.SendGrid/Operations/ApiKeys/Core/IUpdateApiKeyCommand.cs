using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.ApiKeys.Models;

namespace Fluentley.SendGrid.Operations.ApiKeys.Core
{
    public interface IUpdateApiKeyCommand : IContextQuery<IUpdateApiKeyCommand>

    {
        IUpdateApiKeyCommand ByModel(ApiKey apiKey);
        IUpdateApiKeyCommand Id(string value);
        IUpdateApiKeyCommand Name(string value);
        IUpdateApiKeyCommand AddToExistingScopes(params Scope[] scopes);
        IUpdateApiKeyCommand ResetScopes();
    }
}