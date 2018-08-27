using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Users.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Users.Commands
{
    public interface IUpdateUserEmailAddressCommand : IContextQuery<IUpdateUserEmailAddressCommand>

    {
        IUpdateUserEmailAddressCommand ByModel(UserEmailAddress userEmailAddress);
    }

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
                context => context.UpdateUserEmailAddress(this) /*, context =>
                {
                    var validator = new UpdateUserEmailAddressCommandValidator(context);
                    return validator.ValidateAsync(this);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<UserEmailAddress, IUpdateUserEmailAddressCommand, UpdateUserEmailAddressCommand>(
                    this,
                    context => context.UpdateUserEmailAddress(this) /*, context =>
                    {
                        var validator = new UpdateUserEmailAddressCommandValidator(context);
                        return validator.ValidateAsync(this);
                    }*/);
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
    }
}