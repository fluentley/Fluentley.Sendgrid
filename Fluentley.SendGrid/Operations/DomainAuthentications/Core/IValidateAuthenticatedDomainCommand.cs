using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Core
{
    public interface IValidateAuthenticatedDomainCommand : IContextQuery<IValidateAuthenticatedDomainCommand>

    {
        IValidateAuthenticatedDomainCommand ById(string id);
    }
}