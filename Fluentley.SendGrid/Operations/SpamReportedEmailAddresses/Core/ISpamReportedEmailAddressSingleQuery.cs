using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.SpamReportedEmailAddresses.Core
{
    public interface ISpamReportedEmailAddressSingleQuery : IContextQuery<ISpamReportedEmailAddressSingleQuery>

    {
        ISpamReportedEmailAddressSingleQuery ByEmailAddress(string id);
    }
}