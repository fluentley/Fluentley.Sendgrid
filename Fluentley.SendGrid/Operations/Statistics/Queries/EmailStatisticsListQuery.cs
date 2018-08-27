using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Statistics.Core;
using Fluentley.SendGrid.Operations.Statistics.Models;

namespace Fluentley.SendGrid.Operations.Statistics.Queries
{
    internal class EmailStatisticsListQuery : AbstractListQuery<EmailStatistic>, IEmailStatisticsListQuery,
        IQuery<List<EmailStatistic>>
    {
        public EmailStatisticsListQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal bool RetrieveForAllSubUsers { get; set; }
        internal bool RetrieveForAllCategories { get; set; }
        internal List<string> SubUserNames { get; set; }
        internal List<string> Categories { get; set; }

        internal TimeSpan? StartTimeTimeSpan { get; set; }

        internal TimeSpan? EndTimeTimeSpan { get; set; }

        internal int? PageSize { get; set; }

        internal int? PageIndex { get; set; }

        internal StatisticsAggregate StatisticAggregate { get; set; }

        public IEmailStatisticsListQuery UseInMemoryQuery(Action<IQueryOption<EmailStatistic>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public IEmailStatisticsListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IEmailStatisticsListQuery IncludeForAllSubUsers(bool value)
        {
            RetrieveForAllSubUsers = value;
            return this;
        }

        public IEmailStatisticsListQuery IncludeForAllCategories(bool value)
        {
            RetrieveForAllCategories = value;
            return this;
        }

        public IEmailStatisticsListQuery ForCategory(params string[] values)
        {
            if (Categories == null)
                Categories = new List<string>();

            if (values.Any())
                Categories.AddRange(values);

            return this;
        }

        public IEmailStatisticsListQuery ForSubUser(params string[] values)
        {
            if (SubUserNames == null)
                SubUserNames = new List<string>();

            if (values.Any())
                SubUserNames.AddRange(values);

            return this;
        }

        public IEmailStatisticsListQuery FilterByStartTime(TimeSpan value)
        {
            StartTimeTimeSpan = value;
            return this;
        }

        public IEmailStatisticsListQuery FilterByEndTime(TimeSpan value)
        {
            EndTimeTimeSpan = value;
            return this;
        }

        public IEmailStatisticsListQuery AggregateBy(StatisticsAggregate value)
        {
            StatisticAggregate = value;
            return this;
        }

        public IEmailStatisticsListQuery UsePaging(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            return this;
        }

        public Task<IResult<List<EmailStatistic>>> Execute()
        {
            return QueryProcessor.Process<EmailStatistic, IEmailStatisticsListQuery, EmailStatisticsListQuery>(this,
                context => context.EmailStatics(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<EmailStatistic, IEmailStatisticsListQuery, EmailStatisticsListQuery>(this,
                context => context.EmailStatics(this));
        }
    }
}