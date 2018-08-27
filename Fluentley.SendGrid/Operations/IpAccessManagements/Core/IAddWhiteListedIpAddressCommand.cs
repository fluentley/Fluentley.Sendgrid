using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.IpAccessManagements.Core
{
    public interface IAddWhiteListedIpAddressCommand : IContextQuery<IAddWhiteListedIpAddressCommand>

    {
        IAddWhiteListedIpAddressCommand Add(params string[] values);
    }
}