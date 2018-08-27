using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.DomainAuthentications.Models;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Core
{
    public interface IAuthenticatedDomainListQuery :
        IListMemoryFilterQuery<IAuthenticatedDomainListQuery, AuthenticatedDomain>,
        IContextQuery<IAuthenticatedDomainListQuery>
    {
        IAuthenticatedDomainListQuery ExcludeSubusers(bool value);
        IAuthenticatedDomainListQuery UsePaging(int pageIndex, int pageSize);
        IAuthenticatedDomainListQuery AssociatedUserName(string subUserName);
        IAuthenticatedDomainListQuery Domain(string domain);
    }
}