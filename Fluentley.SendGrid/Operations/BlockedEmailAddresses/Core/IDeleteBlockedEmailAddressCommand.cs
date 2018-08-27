using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.BlockedEmailAddresses.Core
{
    public interface IDeleteBlockedEmailAddressCommand : IContextQuery<IDeleteBlockedEmailAddressCommand>

    {
        IDeleteBlockedEmailAddressCommand DeleteAll(bool value);
        IDeleteBlockedEmailAddressCommand AddForDeletion(params string[] values);
    }
}