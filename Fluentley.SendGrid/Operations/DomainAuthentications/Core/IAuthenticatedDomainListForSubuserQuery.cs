using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.DomainAuthentications.Models;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Core
{
    public interface IAuthenticatedDomainListForSubuserQuery :
        IListMemoryFilterQuery<IAuthenticatedDomainListForSubuserQuery, AuthenticatedDomain>,
        IContextQuery<IAuthenticatedDomainListForSubuserQuery>
    {
    }
}