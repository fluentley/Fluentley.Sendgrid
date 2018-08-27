using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.SpamReportedEmailAddresses.Core
{
    public interface IDeleteSpamReportedEmailAddressCommand : IContextQuery<IDeleteSpamReportedEmailAddressCommand>

    {
        IDeleteSpamReportedEmailAddressCommand DeleteAll(bool value);
        IDeleteSpamReportedEmailAddressCommand AddForDeletion(params string[] values);
    }
}