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
    internal class UpdatePlainContentSettingCommand :
        AbstractCommand<PlainContentSetting, UpdatePlainContentSettingCommand>,
        IUpdatePlainContentSettingCommand, ICommand<PlainContentSetting>
    {
        public UpdatePlainContentSettingCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        public Task<IResult<PlainContentSetting>> Execute()
        {
            return Processor
                .Process<PlainContentSetting, IUpdatePlainContentSettingCommand, UpdatePlainContentSettingCommand>(this,
                    context => context.UpdatePlainContentSetting(this));
        }

        public Task<IResult<PlainContentSetting>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<UpdatePlainContentSettingCommand>(commandJson);

            return Processor
                .Process<PlainContentSetting, IUpdatePlainContentSettingCommand, UpdatePlainContentSettingCommand>(this,
                    context => context.UpdatePlainContentSetting(command));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<PlainContentSetting, IUpdatePlainContentSettingCommand, UpdatePlainContentSettingCommand>(this,
                    context => context.UpdatePlainContentSetting(this));
        }

        public IUpdatePlainContentSettingCommand ByModel(PlainContentSetting value)
        {
            Enabled = value.Enabled;
            return this;
        }

        public IUpdatePlainContentSettingCommand IsEnabled(bool value)
        {
            Enabled = value;
            return this;
        }

        public IUpdatePlainContentSettingCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new UpdatePlainContentSettingCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}