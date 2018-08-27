using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Core
{
    public interface IAuthenticatedDomainSingleQuery : IContextQuery<IAuthenticatedDomainSingleQuery>

    {
        IAuthenticatedDomainSingleQuery ById(string id);
    }
}