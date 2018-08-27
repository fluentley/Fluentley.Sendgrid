using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.BlockedEmailAddresses.Core;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.BlockedEmailAddresses.Commands
{
    internal class DeleteBlockedEmailAddressCommand : AbstractCommand<string, DeleteBlockedEmailAddressCommand>,
        IDeleteBlockedEmailAddressCommand,
        ICommand<string>

    {
        public DeleteBlockedEmailAddressCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("emails")]
        public List<string> EmailAddresses { get; set; }

        [JsonProperty("delete_all")]
        public bool ShouldDeleteAll { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IDeleteBlockedEmailAddressCommand, DeleteBlockedEmailAddressCommand>(this,
                context => context.DeleteBlockedEmailAddress(this) /*, context =>
                {
                    var validator = new DeleteBlockedEmailAddressCommandValidator(context);
                    return validator.ValidateAsync(this);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<string, IDeleteBlockedEmailAddressCommand, DeleteBlockedEmailAddressCommand>(this,
                    context => context.DeleteBlockedEmailAddress(this) /*, context =>
                    {
                        var validator = new DeleteBlockedEmailAddressCommandValidator(context);
                        return validator.ValidateAsync(this);
                    }*/);
        }

        public IDeleteBlockedEmailAddressCommand DeleteAll(bool value)
        {
            ShouldDeleteAll = value;
            return this;
        }

        public IDeleteBlockedEmailAddressCommand AddForDeletion(params string[] values)
        {
            if (EmailAddresses == null)
                EmailAddresses = new List<string>();
            if (values.Any())
                EmailAddresses.AddRange(values);

            return this;
        }

        public IDeleteBlockedEmailAddressCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}