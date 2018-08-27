using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.IpPools.Models;

namespace Fluentley.SendGrid.Operations.IpPools.Core
{
    public interface IDeleteIpPoolCommand : IContextQuery<IDeleteIpPoolCommand>

    {
        IDeleteIpPoolCommand ByName(string name);
        IDeleteIpPoolCommand ByModel(IpPool model);
    }
}