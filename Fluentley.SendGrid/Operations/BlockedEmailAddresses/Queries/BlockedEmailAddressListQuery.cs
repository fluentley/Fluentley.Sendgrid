using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Models;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;

namespace Fluentley.SendGrid.Operations.BlockedEmailAddresses.Queries
{
    public interface IBlockedEmailAddressListQuery :
        IListMemoryFilterQuery<IBlockedEmailAddressListQuery, EmailReport>,
        IContextQuery<IBlockedEmailAddressListQuery>
    {
        IBlockedEmailAddressListQuery FilterByStartTime(TimeSpan value);
        IBlockedEmailAddressListQuery FilterByEndTime(TimeSpan value);
        IBlockedEmailAddressListQuery UsePaging(int pageIndex, int pageSize);
    }

    internal class BlockedEmailAddressListQuery : AbstractListQuery<EmailReport>, IBlockedEmailAddressListQuery,
        IQuery<List<EmailReport>>

    {
        public BlockedEmailAddressListQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public TimeSpan? StartTimeTimeSpan { get; set; }

        public TimeSpan? EndTimeTimeSpan { get; set; }

        public int? PageSize { get; set; }

        public int? PageIndex { get; set; }

        public IBlockedEmailAddressListQuery UseInMemoryQuery(Action<IQueryOption<EmailReport>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public IBlockedEmailAddressListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IBlockedEmailAddressListQuery FilterByStartTime(TimeSpan value)
        {
            StartTimeTimeSpan = value;
            return this;
        }

        public IBlockedEmailAddressListQuery FilterByEndTime(TimeSpan value)
        {
            EndTimeTimeSpan = value;
            return this;
        }

        public IBlockedEmailAddressListQuery UsePaging(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            return this;
        }

        public Task<IResult<List<EmailReport>>> Execute()
        {
            return QueryProcessor
                .Process<EmailReport, IBlockedEmailAddressListQuery, BlockedEmailAddressListQuery>(this,
                    context => context.BlockedEmailAddresses(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<EmailReport, IBlockedEmailAddressListQuery, BlockedEmailAddressListQuery>(this,
                    context => context.BlockedEmailAddresses(this));
        }
    }
}