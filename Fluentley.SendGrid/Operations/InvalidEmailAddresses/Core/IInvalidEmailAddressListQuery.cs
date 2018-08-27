using System;
using Fluentley.SendGrid.Common.Models;
using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.InvalidEmailAddresses.Core
{
    public interface IInvalidEmailAddressListQuery :
        IListMemoryFilterQuery<IInvalidEmailAddressListQuery, EmailReport>,
        IContextQuery<IInvalidEmailAddressListQuery>
    {
        IInvalidEmailAddressListQuery FilterByStartTime(TimeSpan value);
        IInvalidEmailAddressListQuery FilterByEndTime(TimeSpan value);
        IInvalidEmailAddressListQuery UsePaging(int pageIndex, int pageSize);
    }
}