using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.SenderIdentities.Core
{
    public interface ISenderIdentitySingleQuery : IContextQuery<ISenderIdentitySingleQuery>

    {
        ISenderIdentitySingleQuery ById(string id);
    }
}