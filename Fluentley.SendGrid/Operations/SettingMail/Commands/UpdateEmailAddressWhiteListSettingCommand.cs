using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SettingMail.Core;
using Fluentley.SendGrid.Operations.SettingMail.Models;
using Fluentley.SendGrid.Operations.SettingMail.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.SettingMail.Commands
{
    internal class UpdateEmailAddressWhiteListSettingCommand :
        AbstractCommand<EmailAddressWhiteListSetting, UpdateEmailAddressWhiteListSettingCommand>,
        IUpdateEmailAddressWhiteListSettingCommand, ICommand<EmailAddressWhiteListSetting>
    {
        public UpdateEmailAddressWhiteListSettingCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("list")]
        public List<string> List { get; set; }

        public Task<IResult<EmailAddressWhiteListSetting>> Execute()
        {
            return Processor
                .Process<EmailAddressWhiteListSetting, IUpdateEmailAddressWhiteListSettingCommand,
                    UpdateEmailAddressWhiteListSettingCommand>(this,
                    context => context.UpdateEmailAddressWhiteListSetting(this));
        }

        public Task<IResult<EmailAddressWhiteListSetting>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<UpdateEmailAddressWhiteListSettingCommand>(commandJson);

            return Processor
                .Process<EmailAddressWhiteListSetting, IUpdateEmailAddressWhiteListSettingCommand,
                    UpdateEmailAddressWhiteListSettingCommand>(this,
                    context => context.UpdateEmailAddressWhiteListSetting(command));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<EmailAddressWhiteListSetting, IUpdateEmailAddressWhiteListSettingCommand,
                    UpdateEmailAddressWhiteListSettingCommand>(this,
                    context => context.UpdateEmailAddressWhiteListSetting(this));
        }

        public IUpdateEmailAddressWhiteListSettingCommand AddEmailAddress(string value)
        {
            if (List == null)
                List = new List<string>();

            List.Add(value);
            return this;
        }

        public IUpdateEmailAddressWhiteListSettingCommand IsEnabled(bool value)
        {
            Enabled = value;
            return this;
        }

        public IUpdateEmailAddressWhiteListSettingCommand ByModel(EmailAddressWhiteListSetting value)
        {
            Enabled = value.Enabled;
            List = value.List;
            return this;
        }

        public IUpdateEmailAddressWhiteListSettingCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new UpdateEmailAddressWhiteListSettingCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}