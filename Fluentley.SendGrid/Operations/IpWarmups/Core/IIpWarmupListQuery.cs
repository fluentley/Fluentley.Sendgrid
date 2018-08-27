using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.IpWarmups.Models;

namespace Fluentley.SendGrid.Operations.IpWarmups.Core
{
    public interface IIpWarmupListQuery : IListMemoryFilterQuery<IIpWarmupListQuery, IpWarmup>,
        IContextQuery<IIpWarmupListQuery>
    {
    }
}