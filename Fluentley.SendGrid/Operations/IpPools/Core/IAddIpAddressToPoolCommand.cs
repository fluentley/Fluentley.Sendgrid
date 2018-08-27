using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.IpPools.Core
{
    public interface IAddIpAddressToPoolCommand : IContextQuery<IAddIpAddressToPoolCommand>

    {
        IAddIpAddressToPoolCommand IpAddress(string ipAddress);
        IAddIpAddressToPoolCommand PoolName(string poolName);
    }
}