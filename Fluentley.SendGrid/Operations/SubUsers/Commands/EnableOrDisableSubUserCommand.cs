using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SubUsers.Core;
using Fluentley.SendGrid.Operations.SubUsers.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.SubUsers.Commands
{
    internal class EnableOrDisableSubUserCommand : AbstractCommand<string, EnableOrDisableSubUserCommand>,
        IEnableOrDisableSubUserCommand,
        ICommand<string>
    {
        private readonly string _defaultApiKey;

        public EnableOrDisableSubUserCommand(string defaultApiKey) : base(defaultApiKey)
        {
            _defaultApiKey = defaultApiKey;
        }

        internal string SubUserName { get; set; }

        internal bool IsDisabled { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IEnableOrDisableSubUserCommand, EnableOrDisableSubUserCommand>(this,
                context => context.EnableOrDisableSubUser(SubUserName, IsDisabled));
        }

        public Task<IResult<string>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<EnableOrDisableSubUserCommand>(commandJson);

            return Processor.Process<string, IEnableOrDisableSubUserCommand, EnableOrDisableSubUserCommand>(this,
                context => context.EnableOrDisableSubUser(command.SubUserName, command.IsDisabled));

        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IEnableOrDisableSubUserCommand, EnableOrDisableSubUserCommand>(
                this,
                context => context.EnableOrDisableSubUser(SubUserName, IsDisabled));
        }

        public IEnableOrDisableSubUserCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IEnableOrDisableSubUserCommand Disable(string subUserName, bool value)
        {
            SubUserName = subUserName;
            IsDisabled = value;
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new EnabledOrDisableSubUserCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}