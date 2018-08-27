using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.IpPools.Core
{
    public interface IRemoveIpAddressFromPoolCommand : IContextQuery<IRemoveIpAddressFromPoolCommand>

    {
        IRemoveIpAddressFromPoolCommand IpAddress(string ipAddress);
        IRemoveIpAddressFromPoolCommand PoolName(string poolName);
    }
}