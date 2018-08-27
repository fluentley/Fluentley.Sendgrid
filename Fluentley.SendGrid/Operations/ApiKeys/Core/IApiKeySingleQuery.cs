using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.ApiKeys.Core
{
    public interface IApiKeySingleQuery : IContextQuery<IApiKeySingleQuery>

    {
        IApiKeySingleQuery ById(string id);
    }
}