using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Models;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;

namespace Fluentley.SendGrid.Operations.InvalidEmailAddresses.Queries
{
    public interface IInvalidEmailAddressSingleQuery : IContextQuery<IInvalidEmailAddressSingleQuery>

    {
        IInvalidEmailAddressSingleQuery ByEmailAddress(string id);
    }

    internal class InvalidEmailAddressSingleQuery : AbstractSingleQuery<EmailReport>,
        IInvalidEmailAddressSingleQuery,
        IQuery<EmailReport>
    {
        public InvalidEmailAddressSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private string EmailAddress { get; set; }

        public IInvalidEmailAddressSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IInvalidEmailAddressSingleQuery ByEmailAddress(string value)
        {
            EmailAddress = value;
            return this;
        }

        public Task<IResult<EmailReport>> Execute()
        {
            return QueryProcessor
                .Process<EmailReport, IInvalidEmailAddressSingleQuery, InvalidEmailAddressSingleQuery>(this,
                    context => context.InvalidEmailAddressByEmailAddress(EmailAddress));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<EmailReport, IInvalidEmailAddressSingleQuery, InvalidEmailAddressSingleQuery>(this,
                    context => context.InvalidEmailAddressByEmailAddress(EmailAddress));
        }
    }
}