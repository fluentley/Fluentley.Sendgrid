using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SpamReportedEmailAddresses.Core;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.SpamReportedEmailAddresses.Commands
{
    internal class DeleteSpamReportedEmailAddressCommand :
        AbstractCommand<string, DeleteSpamReportedEmailAddressCommand>,
        IDeleteSpamReportedEmailAddressCommand,
        ICommand<string>
    {
        public DeleteSpamReportedEmailAddressCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("emails")]
        public List<string> EmailAddresses { get; set; }

        [JsonProperty("delete_all")]
        public bool ShouldDeleteAll { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor
                .Process<string, IDeleteSpamReportedEmailAddressCommand, DeleteSpamReportedEmailAddressCommand>(this,
                    context => context.DeleteSpamReportedEmailAddress(this) /*, context =>
                    {
                        var validator = new DeleteSpamReportedEmailAddressCommandValidator(context);
                        return validator.ValidateAsync(this);
                    }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<string, IDeleteSpamReportedEmailAddressCommand, DeleteSpamReportedEmailAddressCommand>(this,
                    context => context.DeleteSpamReportedEmailAddress(this) /*, context =>
                    {
                        var validator = new DeleteSpamReportedEmailAddressCommandValidator(context);
                        return validator.ValidateAsync(this);
                    }*/);
        }

        public IDeleteSpamReportedEmailAddressCommand DeleteAll(bool value)
        {
            ShouldDeleteAll = value;
            return this;
        }

        public IDeleteSpamReportedEmailAddressCommand AddForDeletion(params string[] values)
        {
            if (EmailAddresses == null)
                EmailAddresses = new List<string>();
            if (values.Any())
                EmailAddresses.AddRange(values);

            return this;
        }

        public IDeleteSpamReportedEmailAddressCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}