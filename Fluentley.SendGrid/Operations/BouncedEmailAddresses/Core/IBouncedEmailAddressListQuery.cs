using System;
using Fluentley.SendGrid.Common.Models;
using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.BouncedEmailAddresses.Core
{
    public interface IBouncedEmailAddressListQuery :
        IListMemoryFilterQuery<IBouncedEmailAddressListQuery, EmailReport>,
        IContextQuery<IBouncedEmailAddressListQuery>
    {
        IBouncedEmailAddressListQuery FilterByStartTime(TimeSpan value);
        IBouncedEmailAddressListQuery FilterByEndTime(TimeSpan value);
    }
}