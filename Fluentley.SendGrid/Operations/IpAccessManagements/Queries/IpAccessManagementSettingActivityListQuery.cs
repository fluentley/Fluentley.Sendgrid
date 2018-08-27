using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.IpAccessManagements.Models;

namespace Fluentley.SendGrid.Operations.IpAccessManagements.Queries
{
    public interface IIpAccessManagementSettingActivityListQuery : IListMemoryFilterQuery<
            IIpAccessManagementSettingActivityListQuery, IpAccessManagementSettingActivity>,
        IContextQuery<IIpAccessManagementSettingActivityListQuery>
    {
        IIpAccessManagementSettingActivityListQuery LimitResults(int value);
    }

    internal class IpAccessManagementSettingActivityListQuery : AbstractListQuery<IpAccessManagementSettingActivity>,
        IIpAccessManagementSettingActivityListQuery, IQuery<List<IpAccessManagementSettingActivity>>
    {
        public IpAccessManagementSettingActivityListQuery(string defailtApiKey) : base(defailtApiKey)
        {
        }

        public int? Limit { get; set; }

        public IIpAccessManagementSettingActivityListQuery UseInMemoryQuery(
            Action<IQueryOption<IpAccessManagementSettingActivity>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public IIpAccessManagementSettingActivityListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IIpAccessManagementSettingActivityListQuery LimitResults(int value)
        {
            Limit = value;
            return this;
        }

        public Task<IResult<List<IpAccessManagementSettingActivity>>> Execute()
        {
            return QueryProcessor
                .Process<IpAccessManagementSettingActivity, IIpAccessManagementSettingActivityListQuery,
                    IpAccessManagementSettingActivityListQuery>(this,
                    context => context.IpAccessManagementSettingActivities(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<IpAccessManagementSettingActivity, IIpAccessManagementSettingActivityListQuery,
                    IpAccessManagementSettingActivityListQuery>(this,
                    context => context.IpAccessManagementSettingActivities(this));
        }
    }
}