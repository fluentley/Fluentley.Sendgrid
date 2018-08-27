using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.IpPools.Core
{
    public interface ICreateIpPoolCommand : IContextQuery<ICreateIpPoolCommand>

    {
        ICreateIpPoolCommand Name(string value);
    }
}