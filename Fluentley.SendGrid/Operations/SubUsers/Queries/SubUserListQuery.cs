using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Alerts.Core.Queries;
using Fluentley.SendGrid.Operations.Alerts.Queries;
using Fluentley.SendGrid.Operations.ApiKeys.Core.Commands;
using Fluentley.SendGrid.Operations.ApiKeys.Queries;
using Fluentley.SendGrid.Operations.BlockedEmailAddresses.Core;
using Fluentley.SendGrid.Operations.BlockedEmailAddresses.Queries;
using Fluentley.SendGrid.Operations.BouncedEmailAddresses.Core;
using Fluentley.SendGrid.Operations.BouncedEmailAddresses.Queries;
using Fluentley.SendGrid.Operations.InvalidEmailAddresses.Core;
using Fluentley.SendGrid.Operations.InvalidEmailAddresses.Queries;
using Fluentley.SendGrid.Operations.MonitorSettings.Core;
using Fluentley.SendGrid.Operations.MonitorSettings.Queries;
using Fluentley.SendGrid.Operations.Reputations.Core;
using Fluentley.SendGrid.Operations.Reputations.Queries;
using Fluentley.SendGrid.Operations.SpamReportedEmailAddresses.Core;
using Fluentley.SendGrid.Operations.SpamReportedEmailAddresses.Queries;
using Fluentley.SendGrid.Operations.SubUsers.Core;
using Fluentley.SendGrid.Operations.SubUsers.Models;

namespace Fluentley.SendGrid.Operations.SubUsers.Queries
{
    internal class SubUserListQuery : AbstractListQuery<SubUser>, ISubUserListQuery
    {
        private readonly string _defaultApiKey;

        public SubUserListQuery(string defaultApiKey) : base(defaultApiKey)
        {
            _defaultApiKey = defaultApiKey;
        }

        internal int? PageSize { get; set; }

        internal int? PageIndex { get; set; }
        internal string SubUserName { get; set; }

        internal MonitorSettingSingleQuery MonitorSettingSingleQuery { get; set; }

        internal ReputationListQuery ReputationListQuery { get; set; }
        internal BlockedEmailAddressListQuery BlockedEmailAddressListQuery { get; set; }

        internal SpamReportedEmailAddressListQuery SpamReportedEmailAddressListQuery { get; set; }

        internal BouncedEmailAddressListQuery BouncedEmailAddressListQuery { get; set; }

        internal InvalidEmailAddressListQuery InvalidEmailAddressListQuery { get; set; }

        internal ApiKeyListQuery ApiKeyListQuery { get; set; }

        internal AlertListQuery AlertListQuery { get; set; }

        public async Task<IResult<List<SubUser>>> Execute()
        {
            var subUserListResult = await QueryProcessor.Process<SubUser, ISubUserListQuery, SubUserListQuery>(this,
                context => context.SubUsers(this));

            if (subUserListResult.IsSuccess && subUserListResult.Data.Any())
                foreach (var subUser in subUserListResult.Data)
                {
                    if (ReputationListQuery != null)
                    {
                        ReputationListQuery
                            .UseContextOption(ContextOptionAction)
                            .AddSubUser(subUser.UserName);

                        var reputationResult = await ReputationListQuery.Execute();

                        if (reputationResult.IsSuccess)
                            subUser.Reputations = reputationResult.Data;
                    }

                    if (MonitorSettingSingleQuery != null)
                    {
                        MonitorSettingSingleQuery
                            .BySubUserName(subUser.UserName)
                            .UseContextOption(ContextOptionAction);

                        var monitorSettingResult = await MonitorSettingSingleQuery.Execute();

                        if (monitorSettingResult.IsSuccess)
                            subUser.MonitorSetting = monitorSettingResult.Data;
                    }

                    Action<IContextOption> contextOption = option => option
                        .OnBehalfOfSubUser(subUser.UserName)
                        .UseApiKey(ContextOption?.ApiKey ?? _defaultApiKey);

                    if (BlockedEmailAddressListQuery != null)
                    {
                        BlockedEmailAddressListQuery.UseContextOption(contextOption);

                        var blockedEmailAddressListResult = await BlockedEmailAddressListQuery.Execute();

                        if (blockedEmailAddressListResult.IsSuccess)
                            subUser.BlockedEmailReports = blockedEmailAddressListResult.Data;
                    }

                    if (BouncedEmailAddressListQuery != null)
                    {
                        BouncedEmailAddressListQuery.UseContextOption(contextOption);

                        var blockedEmailAddressListResult = await BouncedEmailAddressListQuery.Execute();

                        if (blockedEmailAddressListResult.IsSuccess)
                            subUser.BlockedEmailReports = blockedEmailAddressListResult.Data;
                    }

                    if (InvalidEmailAddressListQuery != null)
                    {
                        InvalidEmailAddressListQuery.UseContextOption(contextOption);

                        var invalidEmailAddressListQuery = await InvalidEmailAddressListQuery.Execute();

                        if (invalidEmailAddressListQuery.IsSuccess)
                            subUser.InvalidEmailReports = invalidEmailAddressListQuery.Data;
                    }

                    if (SpamReportedEmailAddressListQuery != null)
                    {
                        SpamReportedEmailAddressListQuery.UseContextOption(contextOption);

                        var spamReportedEmailAddressListQuery = await SpamReportedEmailAddressListQuery.Execute();

                        if (spamReportedEmailAddressListQuery.IsSuccess)
                            subUser.SpamReportedEmails = spamReportedEmailAddressListQuery.Data;
                    }

                    if (AlertListQuery != null)
                    {
                        AlertListQuery.UseContextOption(contextOption);

                        var alertListQuery = await AlertListQuery.Execute();

                        if (alertListQuery.IsSuccess)
                            subUser.Alerts = alertListQuery.Data;
                    }

                    if (ApiKeyListQuery != null)
                    {
                        ApiKeyListQuery.UseContextOption(contextOption);

                        var apiKeyListQuery = await ApiKeyListQuery.Execute();

                        if (apiKeyListQuery.IsSuccess)
                            subUser.ApiKeys = apiKeyListQuery.Data;
                    }
                }

            return subUserListResult;
        }

        public ISubUserListQuery EagerLoadReputrations(Action<IReputationListQuery> queryAction)
        {
            ReputationListQuery = OptionProcessor.Process<IReputationListQuery, ReputationListQuery>(queryAction);
            return this;
        }

        public ISubUserListQuery EagerLoadMonitorSetting(Action<IMonitorSettingSingleQuery> queryAction)
        {
            MonitorSettingSingleQuery =
                OptionProcessor.Process<IMonitorSettingSingleQuery, MonitorSettingSingleQuery>(queryAction);
            return this;
        }

        public ISubUserListQuery EagerLoadBlockedEmailReports(Action<IBlockedEmailAddressListQuery> queryAction)
        {
            BlockedEmailAddressListQuery =
                OptionProcessor.Process<IBlockedEmailAddressListQuery, BlockedEmailAddressListQuery>(queryAction);
            return this;
        }

        public ISubUserListQuery EagerLoadInvalidEmailReports(Action<IInvalidEmailAddressListQuery> queryAction)
        {
            InvalidEmailAddressListQuery =
                OptionProcessor.Process<IInvalidEmailAddressListQuery, InvalidEmailAddressListQuery>(queryAction);
            return this;
        }

        public ISubUserListQuery EagerLoadBouncedEmailReports(Action<IBouncedEmailAddressListQuery> queryAction)
        {
            BouncedEmailAddressListQuery =
                OptionProcessor.Process<IBouncedEmailAddressListQuery, BouncedEmailAddressListQuery>(queryAction);
            return this;
        }

        public ISubUserListQuery EagerLoadSpamReportedEmailReports(
            Action<ISpamReportedEmailAddressListQuery> queryAction)
        {
            SpamReportedEmailAddressListQuery =
                OptionProcessor.Process<ISpamReportedEmailAddressListQuery, SpamReportedEmailAddressListQuery>(
                    queryAction);
            ;
            return this;
        }

        public ISubUserListQuery UseInMemoryQuery(Action<IQueryOption<SubUser>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public ISubUserListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public ISubUserListQuery FilterBySubUserName(string subUserName)
        {
            SubUserName = subUserName;
            return this;
        }

        public ISubUserListQuery UsePaging(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            return this;
        }

        public ISubUserListQuery EagerLoadApiKeys(Action<IApiKeyListQuery> queryAction)
        {
            ApiKeyListQuery = OptionProcessor.Process<IApiKeyListQuery, ApiKeyListQuery>(queryAction);
            return this;
        }

        public ISubUserListQuery EagerLoadAlerts(Action<IAlertListQuery> queryAction)
        {
            AlertListQuery = OptionProcessor.Process<IAlertListQuery, AlertListQuery>(queryAction);
            return this;
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<SubUser, ISubUserListQuery, SubUserListQuery>(this,
                context => context.SubUsers(this));
        }
    }
}