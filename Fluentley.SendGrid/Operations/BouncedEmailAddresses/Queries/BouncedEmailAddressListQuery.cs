using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Models;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.BouncedEmailAddresses.Core;

namespace Fluentley.SendGrid.Operations.BouncedEmailAddresses.Queries
{
    internal class BouncedEmailAddressListQuery : AbstractListQuery<EmailReport>, IBouncedEmailAddressListQuery,
        IQuery<List<EmailReport>>

    {
        public BouncedEmailAddressListQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public TimeSpan? StartTimeTimeSpan { get; set; }

        public TimeSpan? EndTimeTimeSpan { get; set; }

        public IBouncedEmailAddressListQuery UseInMemoryQuery(Action<IQueryOption<EmailReport>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public IBouncedEmailAddressListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IBouncedEmailAddressListQuery FilterByStartTime(TimeSpan value)
        {
            StartTimeTimeSpan = value;
            return this;
        }

        public IBouncedEmailAddressListQuery FilterByEndTime(TimeSpan value)
        {
            EndTimeTimeSpan = value;
            return this;
        }

        public Task<IResult<List<EmailReport>>> Execute()
        {
            return QueryProcessor
                .Process<EmailReport, IBouncedEmailAddressListQuery, BouncedEmailAddressListQuery>(this,
                    context => context.BouncedEmailAddresses(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<EmailReport, IBouncedEmailAddressListQuery, BouncedEmailAddressListQuery>(this,
                    context => context.BouncedEmailAddresses(this));
        }
    }
}