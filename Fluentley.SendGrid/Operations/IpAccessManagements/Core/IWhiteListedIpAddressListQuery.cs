using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.IpAccessManagements.Models;

namespace Fluentley.SendGrid.Operations.IpAccessManagements.Core
{
    public interface IWhiteListedIpAddressListQuery :
        IListMemoryFilterQuery<IWhiteListedIpAddressListQuery, WhiteListedIpAddress>,
        IContextQuery<IWhiteListedIpAddressListQuery>
    {
    }
}