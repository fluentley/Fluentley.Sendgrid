using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.IpAddresses.Core
{
    public interface IAddIpAddressCommand : IContextQuery<IAddIpAddressCommand>

    {
        IAddIpAddressCommand CountOfIpAddresses(int value);
        IAddIpAddressCommand AddSubUser(params string[] values);
        IAddIpAddressCommand IsWarmUp(bool value);
        IAddIpAddressCommand UserCanSend(bool value);
    }
}