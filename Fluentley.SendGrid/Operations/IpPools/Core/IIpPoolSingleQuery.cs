using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.IpPools.Core
{
    public interface IIpPoolSingleQuery : IContextQuery<IIpPoolSingleQuery>

    {
        IIpPoolSingleQuery ByName(string name);
    }
}