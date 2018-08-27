using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Core
{
    public interface
        IRemoveIpAddressFromAuthenticatedDomainCommand : IContextQuery<IRemoveIpAddressFromAuthenticatedDomainCommand>

    {
        IRemoveIpAddressFromAuthenticatedDomainCommand IpAddress(string ipAddress);
        IRemoveIpAddressFromAuthenticatedDomainCommand Id(string id);
    }
}