using System;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.Statistics.Models;
using Fluentley.SendGrid.Operations.Webhooks.Models;

namespace Fluentley.SendGrid.Operations.Webhooks.Core
{
    public interface IWebhookParseStatisticsListQuery :
        IListMemoryFilterQuery<IWebhookParseStatisticsListQuery, WebhookParseStatistics>,
        IContextQuery<IWebhookParseStatisticsListQuery>
    {
        IWebhookParseStatisticsListQuery FilterByStartTime(TimeSpan value);
        IWebhookParseStatisticsListQuery FilterByEndTime(TimeSpan value);
        IWebhookParseStatisticsListQuery AggregateBy(StatisticsAggregate value);
        IWebhookParseStatisticsListQuery UsePaging(int pageIndex, int pageSize);
    }
}