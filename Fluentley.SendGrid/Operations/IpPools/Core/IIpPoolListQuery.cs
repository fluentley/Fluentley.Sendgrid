using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.IpPools.Models;

namespace Fluentley.SendGrid.Operations.IpPools.Core
{
    public interface IIpPoolListQuery : IListMemoryFilterQuery<IIpPoolListQuery, IpPool>,
        IContextQuery<IIpPoolListQuery>
    {
    }
}