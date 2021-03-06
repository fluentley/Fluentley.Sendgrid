﻿using System;
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
    internal class UpdateSpamForwardingSettingCommand :
        AbstractCommand<SpamForwardingSetting, UpdateSpamForwardingSettingCommand>,
        IUpdateSpamForwardingSettingCommand, ICommand<SpamForwardingSetting>
    {
        public UpdateSpamForwardingSettingCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        public Task<IResult<SpamForwardingSetting>> Execute()
        {
            return Processor
                .Process<SpamForwardingSetting, IUpdateSpamForwardingSettingCommand, UpdateSpamForwardingSettingCommand
                >(this,
                    context => context.UpdateSpamForwardingSetting(this));
        }

        public Task<IResult<SpamForwardingSetting>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<UpdateSpamForwardingSettingCommand>(commandJson);

            return Processor
                .Process<SpamForwardingSetting, IUpdateSpamForwardingSettingCommand, UpdateSpamForwardingSettingCommand
                >(this,
                    context => context.UpdateSpamForwardingSetting(command));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<SpamForwardingSetting, IUpdateSpamForwardingSettingCommand, UpdateSpamForwardingSettingCommand
                >(this,
                    context => context.UpdateSpamForwardingSetting(this));
        }

        public IUpdateSpamForwardingSettingCommand Model(SpamForwardingSetting value)
        {
            Email = value.Email;
            Enabled = value.Enabled;
            return this;
        }

        public IUpdateSpamForwardingSettingCommand EmailAddress(string value)
        {
            Email = value;
            return this;
        }

        public IUpdateSpamForwardingSettingCommand IsEnabled(bool value)
        {
            Enabled = value;
            return this;
        }

        public IUpdateSpamForwardingSettingCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new UpdateSpamForwardingSettingCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}