using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.BouncedEmailAddresses.Core;
using Fluentley.SendGrid.Operations.BouncedEmailAddresses.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.BouncedEmailAddresses.Commands
{
    internal class DeleteBouncedEmailAddressCommand : AbstractCommand<string, DeleteBouncedEmailAddressCommand>,
        IDeleteBouncedEmailAddressCommand,
        ICommand<string>

    {
        public DeleteBouncedEmailAddressCommand(string defaultApiKey) : base(defaultApiKey)
        {
            EmailAddresses = new List<string>();
        }

        [JsonProperty("emails")]
        public List<string> EmailAddresses { get; set; }

        [JsonProperty("delete_all")]
        public bool ShouldDeleteAll { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IDeleteBouncedEmailAddressCommand, DeleteBouncedEmailAddressCommand>(this,
                context => context.DeleteBouncedEmailAddress(this) /*, context =>
                {
                    var validator = new DeleteBouncedEmailAddressCommandValidator(context);
                    return validator.ValidateAsync(this);
                }*/);
        }

        public Task<IResult<string>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<DeleteBouncedEmailAddressCommand>(commandJson);

            return Processor.Process<string, IDeleteBouncedEmailAddressCommand, DeleteBouncedEmailAddressCommand>(this,
                context => context.DeleteBouncedEmailAddress(command) /*, context =>
                {
                    var validator = new DeleteBouncedEmailAddressCommandValidator(context);
                    return validator.ValidateAsync(this);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<string, IDeleteBouncedEmailAddressCommand, DeleteBouncedEmailAddressCommand>(this,
                    context => context.DeleteBouncedEmailAddress(this) /*, context =>
                    {
                        var validator = new DeleteBouncedEmailAddressCommandValidator(context);
                        return validator.ValidateAsync(this);
                    }*/);
        }

        public IDeleteBouncedEmailAddressCommand DeleteAll(bool value)
        {
            ShouldDeleteAll = value;
            return this;
        }

        public IDeleteBouncedEmailAddressCommand AddForDeletion(params string[] values)
        {
            if (EmailAddresses == null)
                EmailAddresses = new List<string>();

            if (values.Any())
                EmailAddresses.AddRange(values);

            return this;
        }

        public IDeleteBouncedEmailAddressCommand UseContextOption(Action<IContextOption> option)
        {
          
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new DeleteBouncedEmailAddressCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}