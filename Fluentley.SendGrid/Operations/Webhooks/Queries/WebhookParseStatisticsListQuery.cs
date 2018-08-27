using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Statistics.Models;
using Fluentley.SendGrid.Operations.Webhooks.Core;
using Fluentley.SendGrid.Operations.Webhooks.Models;

namespace Fluentley.SendGrid.Operations.Webhooks.Queries
{
    internal class WebhookParseStatisticsListQuery : AbstractListQuery<WebhookParseStatistics>,
        IWebhookParseStatisticsListQuery,
        IQuery<List<WebhookParseStatistics>>
    {
        public WebhookParseStatisticsListQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal TimeSpan? StartTimeTimeSpan { get; set; }

        internal TimeSpan? EndTimeTimeSpan { get; set; }

        internal int? PageSize { get; set; }

        internal int? PageIndex { get; set; }

        internal StatisticsAggregate StatisticAggregate { get; set; }

        public Task<IResult<List<WebhookParseStatistics>>> Execute()
        {
            return QueryProcessor
                .Process<WebhookParseStatistics, IWebhookParseStatisticsListQuery, WebhookParseStatisticsListQuery>(
                    this,
                    context => context.WebhookParseStatistics(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<WebhookParseStatistics, IWebhookParseStatisticsListQuery, WebhookParseStatisticsListQuery>(
                    this,
                    context => context.WebhookParseStatistics(this));
        }

        public IWebhookParseStatisticsListQuery UseInMemoryQuery(Action<IQueryOption<WebhookParseStatistics>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public IWebhookParseStatisticsListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IWebhookParseStatisticsListQuery FilterByStartTime(TimeSpan value)
        {
            StartTimeTimeSpan = value;
            return this;
        }

        public IWebhookParseStatisticsListQuery FilterByEndTime(TimeSpan value)
        {
            EndTimeTimeSpan = value;
            return this;
        }

        public IWebhookParseStatisticsListQuery AggregateBy(StatisticsAggregate value)
        {
            StatisticAggregate = value;
            return this;
        }

        public IWebhookParseStatisticsListQuery UsePaging(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            return this;
        }
    }
}