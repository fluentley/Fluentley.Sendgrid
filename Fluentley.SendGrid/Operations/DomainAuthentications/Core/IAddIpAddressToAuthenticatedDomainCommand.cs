using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Core
{
    public interface
        IAddIpAddressToAuthenticatedDomainCommand : IContextQuery<IAddIpAddressToAuthenticatedDomainCommand>

    {
        IAddIpAddressToAuthenticatedDomainCommand IpAddress(string ipAddress);
        IAddIpAddressToAuthenticatedDomainCommand Id(string id);
    }
}