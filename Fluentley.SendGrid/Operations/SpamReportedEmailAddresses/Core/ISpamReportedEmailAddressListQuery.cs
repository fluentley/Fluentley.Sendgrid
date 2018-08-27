using System;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.SpamReportedEmailAddresses.Models;

namespace Fluentley.SendGrid.Operations.SpamReportedEmailAddresses.Core
{
    public interface ISpamReportedEmailAddressListQuery :
        IListMemoryFilterQuery<ISpamReportedEmailAddressListQuery, SpamReportedEmailAddress>,
        IContextQuery<ISpamReportedEmailAddressListQuery>
    {
        ISpamReportedEmailAddressListQuery FilterByStartTime(TimeSpan value);
        ISpamReportedEmailAddressListQuery FilterByEndTime(TimeSpan value);
        ISpamReportedEmailAddressListQuery UsePaging(int pageIndex, int pageSize);
    }
}