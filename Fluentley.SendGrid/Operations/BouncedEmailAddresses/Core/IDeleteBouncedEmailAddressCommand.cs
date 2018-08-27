using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.BouncedEmailAddresses.Core
{
    public interface IDeleteBouncedEmailAddressCommand : IContextQuery<IDeleteBouncedEmailAddressCommand>

    {
        IDeleteBouncedEmailAddressCommand DeleteAll(bool value);
        IDeleteBouncedEmailAddressCommand AddForDeletion(params string[] values);
    }
}