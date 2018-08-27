using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Core
{
    public interface
        IAssociateSubuserToAuthenticatedDomainCommand : IContextQuery<IAssociateSubuserToAuthenticatedDomainCommand>

    {
        IAssociateSubuserToAuthenticatedDomainCommand DomainId(string id);
        IAssociateSubuserToAuthenticatedDomainCommand SubUser(string value);
    }
}