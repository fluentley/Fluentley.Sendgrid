using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.ApiKeys.Models;

namespace Fluentley.SendGrid.Operations.ApiKeys.Core.Queires
{
    public interface IUpdateApiKeyCommand : IContextQuery<IUpdateApiKeyCommand>

    {
        /// <summary>
        ///     Update By ApiKey Model
        /// </summary>
        /// <param name="apiKey">ApiKey Model</param>
        /// <returns></returns>
        IUpdateApiKeyCommand ByModel(ApiKey apiKey);

        /// <summary>
        ///     Id of the ApiKey
        /// </summary>
        /// <param name="value">ApiKey Id <c>[Required]</param>
        /// <returns></returns>
        IUpdateApiKeyCommand Id(string value);

        /// <summary>
        ///     The new name of the API Key.
        /// </summary>
        /// <param name="value">Name <c>[Optional]</c></param>
        /// <returns></returns>
        IUpdateApiKeyCommand Name(string value);

        /// <summary>
        ///     Adds to existing scopes.
        /// </summary>
        /// <param name="scopes">The scopes.</param>
        /// <returns></returns>
        IUpdateApiKeyCommand AddToExistingScopes(params Scope[] scopes);

        /// <summary>
        ///     Resets the scopes.
        /// </summary>
        /// <returns></returns>
        IUpdateApiKeyCommand ResetScopes();
    }
}