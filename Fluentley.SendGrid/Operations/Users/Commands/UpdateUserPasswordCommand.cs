using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Users.Commands
{
    public interface IUpdateUserPasswordCommand : IContextQuery<IUpdateUserPasswordCommand>

    {
        IUpdateUserPasswordCommand Password(string oldPassword, string newPassword);
    }

    internal class UpdateUserPasswordCommand : AbstractCommand<string, UpdateUserPasswordCommand>,
        IUpdateUserPasswordCommand, ICommand<string>
    {
        public UpdateUserPasswordCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("new_password")]
        internal string NewPassword { get; set; }

        [JsonProperty("old_password")]
        internal string OldPassword { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IUpdateUserPasswordCommand, UpdateUserPasswordCommand>(this,
                context => context.UpdateUserPassword(this) /*, context =>
                {
                    var validator = new UpdateUserPasswordCommandValidator(context);
                    return validator.ValidateAsync(this);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IUpdateUserPasswordCommand, UpdateUserPasswordCommand>(this,
                context => context.UpdateUserPassword(this) /*, context =>
                {
                    var validator = new UpdateUserPasswordCommandValidator(context);
                    return validator.ValidateAsync(this);
                }*/);
        }

        public IUpdateUserPasswordCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IUpdateUserPasswordCommand Password(string oldPassword, string newPassword)
        {
            OldPassword = oldPassword;
            NewPassword = newPassword;
            return this;
        }
    }
}