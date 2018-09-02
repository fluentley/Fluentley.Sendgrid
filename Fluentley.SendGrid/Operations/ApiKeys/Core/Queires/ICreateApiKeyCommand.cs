using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.ApiKeys.Models;

namespace Fluentley.SendGrid.Operations.ApiKeys.Core.Queires
{
    public interface ICreateApiKeyCommand : IContextQuery<ICreateApiKeyCommand>

    {
        ICreateApiKeyCommand ByModel(ApiKey apiKey);
        /// <summary>
        /// The name you will use to describe this API Key.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        ICreateApiKeyCommand Name(string name);
        /// <summary>
        /// Adds the scope.
        /// </summary>
        /// <param name="scopes">The individual permissions that you are giving to this API Key.
        /// </param>
        /// <returns></returns>
        ICreateApiKeyCommand AddScope(params Scope[] scopes);
    }
}