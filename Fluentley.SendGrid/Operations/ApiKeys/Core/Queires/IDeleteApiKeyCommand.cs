using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.ApiKeys.Models;

namespace Fluentley.SendGrid.Operations.ApiKeys.Core.Queires
{
    public interface IDeleteApiKeyCommand : IContextQuery<IDeleteApiKeyCommand>
    {
        /// <summary>
        ///     Delete By ApiKey Id
        /// </summary>
        /// <param name="id">Id of the Alert</param>
        /// <returns></returns>
        IDeleteApiKeyCommand ById(string id);

        /// <summary>
        ///     Delete By ApiKey Model
        /// </summary>
        /// <param name="value">ApiKey Model</param>
        /// <returns></returns>
        IDeleteApiKeyCommand ByModel(ApiKey value);
    }
}