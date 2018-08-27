using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.IpAddresses.Models;

namespace Fluentley.SendGrid.Operations.IpAddresses.Core
{
    public interface IAssignedIpAddressListQuery :
        IListMemoryFilterQuery<IAssignedIpAddressListQuery, AssignedIpAddress>,
        IContextQuery<IAssignedIpAddressListQuery>
    {
    }
}