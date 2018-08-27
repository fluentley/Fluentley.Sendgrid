using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.IpAddresses.Models;

namespace Fluentley.SendGrid.Operations.IpAddresses.Core
{
    public interface IRemainingIpAddressListQuery :
        IListMemoryFilterQuery<IRemainingIpAddressListQuery, RemainingIpAddress>,
        IContextQuery<IRemainingIpAddressListQuery>
    {
    }
}