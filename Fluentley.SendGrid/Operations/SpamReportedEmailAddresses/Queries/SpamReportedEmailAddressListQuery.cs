using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SpamReportedEmailAddresses.Models;

namespace Fluentley.SendGrid.Operations.SpamReportedEmailAddresses.Queries
{
    public interface ISpamReportedEmailAddressListQuery :
        IListMemoryFilterQuery<ISpamReportedEmailAddressListQuery, SpamReportedEmailAddress>,
        IContextQuery<ISpamReportedEmailAddressListQuery>
    {
        ISpamReportedEmailAddressListQuery FilterByStartTime(TimeSpan value);
        ISpamReportedEmailAddressListQuery FilterByEndTime(TimeSpan value);
        ISpamReportedEmailAddressListQuery UsePaging(int pageIndex, int pageSize);
    }

    internal class SpamReportedEmailAddressListQuery : AbstractListQuery<SpamReportedEmailAddress>,
        ISpamReportedEmailAddressListQuery,
        IQuery<List<SpamReportedEmailAddress>>
    {
        public SpamReportedEmailAddressListQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public TimeSpan? StartTimeTimeSpan { get; set; }

        public TimeSpan? EndTimeTimeSpan { get; set; }

        public int? PageSize { get; set; }

        public int? PageIndex { get; set; }

        public Task<IResult<List<SpamReportedEmailAddress>>> Execute()
        {
            return QueryProcessor
                .Process<SpamReportedEmailAddress, ISpamReportedEmailAddressListQuery, SpamReportedEmailAddressListQuery
                >(this, context => context.SpamReportedEmailAddresses(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<SpamReportedEmailAddress, ISpamReportedEmailAddressListQuery, SpamReportedEmailAddressListQuery
                >(this, context => context.SpamReportedEmailAddresses(this));
        }

        public ISpamReportedEmailAddressListQuery UseInMemoryQuery(
            Action<IQueryOption<SpamReportedEmailAddress>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public ISpamReportedEmailAddressListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public ISpamReportedEmailAddressListQuery FilterByStartTime(TimeSpan value)
        {
            StartTimeTimeSpan = value;
            return this;
        }

        public ISpamReportedEmailAddressListQuery FilterByEndTime(TimeSpan value)
        {
            EndTimeTimeSpan = value;
            return this;
        }

        public ISpamReportedEmailAddressListQuery UsePaging(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            return this;
        }
    }
}