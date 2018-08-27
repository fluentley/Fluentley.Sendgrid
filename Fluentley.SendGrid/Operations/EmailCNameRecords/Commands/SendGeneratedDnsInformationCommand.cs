using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.EmailCNameRecords.Core;
using Fluentley.SendGrid.Operations.EmailCNameRecords.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.EmailCNameRecords.Commands
{
    internal class SendGeneratedDnsInformationCommand :
        AbstractCommand<SendDnsInformationResult, SendGeneratedDnsInformationCommand>,
        ISendGeneratedDnsInformationCommand,
        ICommand<SendDnsInformationResult>
    {
        public SendGeneratedDnsInformationCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("link_id")]
        internal string LinkIdForSend { get; set; }

        [JsonProperty("domain_id")]
        internal string DomainIdForSend { get; set; }

        [JsonProperty("email")]
        internal string EmailAddressForSend { get; set; }

        [JsonProperty("message")]
        internal string MessageForSend { get; set; }

        public Task<IResult<SendDnsInformationResult>> Execute()
        {
            return Processor
                .Process<SendDnsInformationResult, ISendGeneratedDnsInformationCommand,
                    SendGeneratedDnsInformationCommand>(this,
                    context => context.SendGeneratedDnsInformation(this) /*, context =>
                    {
                        var validator = new SendGeneratedDnsInformationCommandValidator(context);
                        return validator.ValidateAsync(this);
                    }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<SendDnsInformationResult, ISendGeneratedDnsInformationCommand,
                    SendGeneratedDnsInformationCommand>(this,
                    context => context.SendGeneratedDnsInformation(this) /*, context =>
                    {
                        var validator = new SendGeneratedDnsInformationCommandValidator(context);
                        return validator.ValidateAsync(this);
                    }*/);
        }

        public ISendGeneratedDnsInformationCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public ISendGeneratedDnsInformationCommand LinkId(string linkId)
        {
            LinkIdForSend = linkId;
            return this;
        }

        public ISendGeneratedDnsInformationCommand DomainId(string domainId)
        {
            DomainIdForSend = domainId;
            return this;
        }

        public ISendGeneratedDnsInformationCommand EmailAddress(string emailAddress)
        {
            EmailAddressForSend = emailAddress;
            return this;
        }

        public ISendGeneratedDnsInformationCommand Message(string message)
        {
            MessageForSend = message;
            return this;
        }
    }
}