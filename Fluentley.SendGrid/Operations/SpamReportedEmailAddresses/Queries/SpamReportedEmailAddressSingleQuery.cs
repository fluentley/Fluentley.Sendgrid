using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SpamReportedEmailAddresses.Core;
using Fluentley.SendGrid.Operations.SpamReportedEmailAddresses.Models;

namespace Fluentley.SendGrid.Operations.SpamReportedEmailAddresses.Queries
{
    internal class SpamReportedEmailAddressSingleQuery : AbstractSingleQuery<SpamReportedEmailAddress>,
        ISpamReportedEmailAddressSingleQuery,
        IQuery<SpamReportedEmailAddress>
    {
        public SpamReportedEmailAddressSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private string EmailAddress { get; set; }

        public Task<IResult<SpamReportedEmailAddress>> Execute()
        {
            return QueryProcessor
                .Process<SpamReportedEmailAddress, ISpamReportedEmailAddressSingleQuery,
                    SpamReportedEmailAddressSingleQuery>(this,
                    context => context.SpamReportedEmailAddressByEmailAddress(EmailAddress));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<SpamReportedEmailAddress, ISpamReportedEmailAddressSingleQuery,
                    SpamReportedEmailAddressSingleQuery>(this,
                    context => context.SpamReportedEmailAddressByEmailAddress(EmailAddress));
        }

        public ISpamReportedEmailAddressSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public ISpamReportedEmailAddressSingleQuery ByEmailAddress(string value)
        {
            EmailAddress = value;
            return this;
        }
    }
}