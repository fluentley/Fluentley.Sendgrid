using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.ApiKeys.Models;

namespace Fluentley.SendGrid.Operations.ApiKeys.Core
{
    public interface IDeleteApiKeyCommand : IContextQuery<IDeleteApiKeyCommand>

    {
        IDeleteApiKeyCommand ById(string id);
        IDeleteApiKeyCommand ByModel(ApiKey value);
    }
}