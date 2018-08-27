using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Models;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.BlockedEmailAddresses.Core;

namespace Fluentley.SendGrid.Operations.BlockedEmailAddresses.Queries
{
    internal class BlockedEmailAddressSingleQuery : AbstractSingleQuery<EmailReport>,
        IBlockedEmailAddressSingleQuery,
        IQuery<EmailReport>
    {
        public BlockedEmailAddressSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private string EmailAddress { get; set; }

        public IBlockedEmailAddressSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IBlockedEmailAddressSingleQuery ByEmailAddress(string value)
        {
            EmailAddress = value;
            return this;
        }

        public Task<IResult<EmailReport>> Execute()
        {
            return QueryProcessor
                .Process<EmailReport, IBlockedEmailAddressSingleQuery, BlockedEmailAddressSingleQuery>(this,
                    context => context.BlockedEmailAddressByEmailAddress(EmailAddress));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<EmailReport, IBlockedEmailAddressSingleQuery, BlockedEmailAddressSingleQuery>(this,
                    context => context.BlockedEmailAddressByEmailAddress(EmailAddress));
        }
    }
}