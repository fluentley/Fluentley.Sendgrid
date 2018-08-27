using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Models;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;

namespace Fluentley.SendGrid.Operations.BouncedEmailAddresses.Queries
{
    public interface IBouncedEmailAddressSingleQuery : IContextQuery<IBouncedEmailAddressSingleQuery>

    {
        IBouncedEmailAddressSingleQuery ByEmailAddress(string id);
    }

    internal class BouncedEmailAddressSingleQuery : AbstractSingleQuery<EmailReport>,
        IBouncedEmailAddressSingleQuery,
        IQuery<EmailReport>
    {
        public BouncedEmailAddressSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private string EmailAddress { get; set; }

        public IBouncedEmailAddressSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IBouncedEmailAddressSingleQuery ByEmailAddress(string value)
        {
            EmailAddress = value;
            return this;
        }

        public Task<IResult<EmailReport>> Execute()
        {
            return QueryProcessor
                .Process<EmailReport, IBouncedEmailAddressSingleQuery, BouncedEmailAddressSingleQuery>(this,
                    context => context.BouncedEmailAddressByEmailAddress(EmailAddress));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<EmailReport, IBouncedEmailAddressSingleQuery, BouncedEmailAddressSingleQuery>(this,
                    context => context.BouncedEmailAddressByEmailAddress(EmailAddress));
        }
    }
}