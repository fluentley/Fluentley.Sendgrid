using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.IpWarmups.Core
{
    public interface IIpWarmupSingleQuery : IContextQuery<IIpWarmupSingleQuery>

    {
        IIpWarmupSingleQuery ByIpAddress(string ipAddress);
    }
}