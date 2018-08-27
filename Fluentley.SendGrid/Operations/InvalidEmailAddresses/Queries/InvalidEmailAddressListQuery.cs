using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Models;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.InvalidEmailAddresses.Core;

namespace Fluentley.SendGrid.Operations.InvalidEmailAddresses.Queries
{
    internal class InvalidEmailAddressListQuery : AbstractListQuery<EmailReport>, IInvalidEmailAddressListQuery,
        IQuery<List<EmailReport>>
    {
        public InvalidEmailAddressListQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public TimeSpan? StartTimeTimeSpan { get; set; }

        public TimeSpan? EndTimeTimeSpan { get; set; }

        public int? PageSize { get; set; }

        public int? PageIndex { get; set; }

        public IInvalidEmailAddressListQuery UseInMemoryQuery(Action<IQueryOption<EmailReport>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public IInvalidEmailAddressListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IInvalidEmailAddressListQuery FilterByStartTime(TimeSpan value)
        {
            StartTimeTimeSpan = value;
            return this;
        }

        public IInvalidEmailAddressListQuery FilterByEndTime(TimeSpan value)
        {
            EndTimeTimeSpan = value;
            return this;
        }

        public IInvalidEmailAddressListQuery UsePaging(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            return this;
        }

        public Task<IResult<List<EmailReport>>> Execute()
        {
            return QueryProcessor
                .Process<EmailReport, IInvalidEmailAddressListQuery, InvalidEmailAddressListQuery>(this,
                    context => context.InvalidEmailAddresses(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<EmailReport, IInvalidEmailAddressListQuery, InvalidEmailAddressListQuery>(this,
                    context => context.InvalidEmailAddresses(this));
        }
    }
}