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
    internal class UpdateUserNameCommand : AbstractCommand<User, UpdateUserNameCommand>, IUpdateUserNameCommand,
        ICommand<User>
    {
        public UpdateUserNameCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("username")]
        internal string UserName { get; set; }

        public Task<IResult<User>> Execute()
        {
            return Processor.Process<User, IUpdateUserNameCommand, UpdateUserNameCommand>(this,
                context => context.UpdateUserName(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<User, IUpdateUserNameCommand, UpdateUserNameCommand>(this,
                context => context.UpdateUserName(this));
        }

        public IUpdateUserNameCommand ByModel(User user)
        {
            UserName = user.UserName;

            return this;
        }

        public IUpdateUserNameCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new UpdateUserNameCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}