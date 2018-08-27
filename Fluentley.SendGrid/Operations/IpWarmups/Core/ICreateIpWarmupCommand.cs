using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.IpWarmups.Core
{
    public interface ICreateIpWarmupCommand : IContextQuery<ICreateIpWarmupCommand>

    {
        ICreateIpWarmupCommand IpAddress(string value);
    }
}