using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.InvalidEmailAddresses.Core
{
    public interface IDeleteInvalidEmailAddressCommand : IContextQuery<IDeleteInvalidEmailAddressCommand>

    {
        IDeleteInvalidEmailAddressCommand DeleteAll(bool value);
        IDeleteInvalidEmailAddressCommand AddForDeletion(params string[] values);
    }
}