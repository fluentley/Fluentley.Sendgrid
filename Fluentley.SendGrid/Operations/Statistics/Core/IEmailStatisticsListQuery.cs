using System;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.Statistics.Models;

namespace Fluentley.SendGrid.Operations.Statistics.Core
{
    public interface IEmailStatisticsListQuery : IListMemoryFilterQuery<IEmailStatisticsListQuery, EmailStatistic>,
        IContextQuery<IEmailStatisticsListQuery>
    {
        IEmailStatisticsListQuery ForCategory(params string[] values);
        IEmailStatisticsListQuery ForSubUser(params string[] values);
        IEmailStatisticsListQuery FilterByStartTime(TimeSpan value);
        IEmailStatisticsListQuery FilterByEndTime(TimeSpan value);
        IEmailStatisticsListQuery AggregateBy(StatisticsAggregate value);
        IEmailStatisticsListQuery UsePaging(int pageIndex, int pageSize);
        IEmailStatisticsListQuery IncludeForAllSubUsers(bool value);
        IEmailStatisticsListQuery IncludeForAllCategories(bool value);
    }
}