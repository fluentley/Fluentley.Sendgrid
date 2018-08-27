using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.IpAddresses.Models;

namespace Fluentley.SendGrid.Operations.IpAddresses.Core
{
    public interface IIpAddressListQuery : IListMemoryFilterQuery<IIpAddressListQuery, IpAddress>,
        IContextQuery<IIpAddressListQuery>
    {
        IIpAddressListQuery UsePaging(int pageIndex, int pageSize);
        IIpAddressListQuery FilterBySubuser(string value);
        IIpAddressListQuery ShouldExcludeWhiteLabels(bool value);
        IIpAddressListQuery SortBy(SortDirection value);
        IIpAddressListQuery FilterByIpAddress(string value);
    }
}