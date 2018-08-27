using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.IpPools.Core
{
    public interface IUpdateIpPoolCommand : IContextQuery<IUpdateIpPoolCommand>

    {
        IUpdateIpPoolCommand ChangeName(string oldName, string newName);
    }
}