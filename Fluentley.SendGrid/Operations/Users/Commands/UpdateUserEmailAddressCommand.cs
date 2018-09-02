using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Users.Core;
using Fluentley.SendGrid.Operations.Users.Models;
using Fluentley.SendGrid.Operations.Users.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Users.Commands
{
    internal class UpdateUserEmailAddressCommand : AbstractCommand<UserEmailAddress, UpdateUserEmailAddressCommand>,
        IUpdateUserEmailAddressCommand,
        ICommand<UserEmailAddress>
    {
        public UpdateUserEmailAddressCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("email")]
        public string EmailAddress { get; set; }

        public Task<IResult<UserEmailAddress>> Execute()
        {
            return Processor.Process<UserEmailAddress, IUpdateUserEmailAddressCommand, UpdateUserEmailAddressCommand>(
                this,
                context => context.UpdateUserEmailAddress(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<UserEmailAddress, IUpdateUserEmailAddressCommand, UpdateUserEmailAddressCommand>(
                    this,
                    context => context.UpdateUserEmailAddress(this));
        }

        public IUpdateUserEmailAddressCommand ByModel(UserEmailAddress userEmailAddress)
        {
            EmailAddress = userEmailAddress.EmailAddress;
            return this;
        }

        public IUpdateUserEmailAddressCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new UpdateUserEmailAddressCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}