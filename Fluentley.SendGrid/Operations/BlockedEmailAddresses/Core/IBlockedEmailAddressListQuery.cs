using System;
using Fluentley.SendGrid.Common.Models;
using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.BlockedEmailAddresses.Core
{
    public interface IBlockedEmailAddressListQuery :
        IListMemoryFilterQuery<IBlockedEmailAddressListQuery, EmailReport>,
        IContextQuery<IBlockedEmailAddressListQuery>
    {
        IBlockedEmailAddressListQuery FilterByStartTime(TimeSpan value);
        IBlockedEmailAddressListQuery FilterByEndTime(TimeSpan value);
        IBlockedEmailAddressListQuery UsePaging(int pageIndex, int pageSize);
    }
}