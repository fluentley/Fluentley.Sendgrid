using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.IpAddresses.Core
{
    public interface IIpAddressSingleQuery : IContextQuery<IIpAddressSingleQuery>

    {
        IIpAddressSingleQuery ByIpAddress(string ipAddress);
    }
}