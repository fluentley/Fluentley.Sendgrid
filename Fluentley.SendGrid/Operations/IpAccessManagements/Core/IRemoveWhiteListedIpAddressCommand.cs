using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.IpAccessManagements.Core
{
    public interface IRemoveWhiteListedIpAddressCommand : IContextQuery<IRemoveWhiteListedIpAddressCommand>

    {
        IRemoveWhiteListedIpAddressCommand IpAddressId(params string[] ipAddressId);
    }
}