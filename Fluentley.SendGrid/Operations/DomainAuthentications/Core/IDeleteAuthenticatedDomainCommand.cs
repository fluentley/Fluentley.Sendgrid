using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.DomainAuthentications.Models;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Core
{
    public interface IDeleteAuthenticatedDomainCommand : IContextQuery<IDeleteAuthenticatedDomainCommand>

    {
        IDeleteAuthenticatedDomainCommand ById(string id);
        IDeleteAuthenticatedDomainCommand ByModel(AuthenticatedDomain model);
    }
}