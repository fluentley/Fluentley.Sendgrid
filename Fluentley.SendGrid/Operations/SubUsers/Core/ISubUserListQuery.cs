using System;
using System.Collections.Generic;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.Alerts.Core;
using Fluentley.SendGrid.Operations.ApiKeys.Core;
using Fluentley.SendGrid.Operations.BlockedEmailAddresses.Core;
using Fluentley.SendGrid.Operations.BouncedEmailAddresses.Core;
using Fluentley.SendGrid.Operations.InvalidEmailAddresses.Core;
using Fluentley.SendGrid.Operations.MonitorSettings.Core;
using Fluentley.SendGrid.Operations.Reputations.Core;
using Fluentley.SendGrid.Operations.SpamReportedEmailAddresses.Core;
using Fluentley.SendGrid.Operations.SubUsers.Models;

namespace Fluentley.SendGrid.Operations.SubUsers.Core
{
    public interface ISubUserListQuery : IListMemoryFilterQuery<ISubUserListQuery, SubUser>,
        IContextQuery<ISubUserListQuery>, IQuery<List<SubUser>>
    {
        ISubUserListQuery EagerLoadReputrations(Action<IReputationListQuery> queryAction);
        ISubUserListQuery EagerLoadMonitorSetting(Action<IMonitorSettingSingleQuery> queryAction);
        ISubUserListQuery EagerLoadBlockedEmailReports(Action<IBlockedEmailAddressListQuery> queryAction);
        ISubUserListQuery EagerLoadInvalidEmailReports(Action<IInvalidEmailAddressListQuery> queryAction);
        ISubUserListQuery EagerLoadBouncedEmailReports(Action<IBouncedEmailAddressListQuery> queryAction);

        ISubUserListQuery EagerLoadSpamReportedEmailReports(Action<ISpamReportedEmailAddressListQuery> queryAction);

        ISubUserListQuery FilterBySubUserName(string subUserName);
        ISubUserListQuery UsePaging(int pageIndex, int pageSize);
        ISubUserListQuery EagerLoadApiKeys(Action<IApiKeyListQuery> queryAction);
        ISubUserListQuery EagerLoadAlerts(Action<IAlertListQuery> queryAction);
    }
}