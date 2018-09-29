using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.InvalidEmailAddresses.Core;
using Fluentley.SendGrid.Operations.InvalidEmailAddresses.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.InvalidEmailAddresses.Commands
{
    internal class DeleteInvalidEmailAddressCommand : AbstractCommand<string, DeleteInvalidEmailAddressCommand>,
        IDeleteInvalidEmailAddressCommand,
        ICommand<string>
    {
        public DeleteInvalidEmailAddressCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("emails")]
        public List<string> EmailAddresses { get; set; }

        [JsonProperty("delete_all")]
        public bool ShouldDeleteAll { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IDeleteInvalidEmailAddressCommand, DeleteInvalidEmailAddressCommand>(this,
                context => context.DeleteInvalidEmailAddress(this));
        }

        public Task<IResult<string>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<DeleteInvalidEmailAddressCommand>(commandJson);

            return Processor.Process<string, IDeleteInvalidEmailAddressCommand, DeleteInvalidEmailAddressCommand>(this,
                context => context.DeleteInvalidEmailAddress(command));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<string, IDeleteInvalidEmailAddressCommand, DeleteInvalidEmailAddressCommand>(this,
                    context => context.DeleteInvalidEmailAddress(this));
        }

        public IDeleteInvalidEmailAddressCommand DeleteAll(bool value)
        {
            ShouldDeleteAll = value;
            return this;
        }

        public IDeleteInvalidEmailAddressCommand AddForDeletion(params string[] values)
        {
            if (EmailAddresses == null)
                EmailAddresses = new List<string>();
            if (values.Any())
                EmailAddresses.AddRange(values);

            return this;
        }

        public IDeleteInvalidEmailAddressCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new DeleteInvalidEmailAddressCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}