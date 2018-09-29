﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SettingInboundParse.Core;
using Fluentley.SendGrid.Operations.SettingInboundParse.Models;
using Fluentley.SendGrid.Operations.SettingInboundParse.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.SettingInboundParse.Commands
{
    internal class CreateParseSettingCommand : AbstractCommand<ParseSetting, CreateParseSettingCommand>,
        ICreateParseSettingCommand, ICommand<ParseSetting>
    {
        public CreateParseSettingCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("hostname")]
        public string HostnameOfParseSettings { get; set; }

        [JsonProperty("url")]
        public string UrlOfParseSettings { get; set; }

        [JsonProperty("spam_check")]
        public bool? SpamCheckOfParseSettings { get; set; }

        [JsonProperty("send_raw")]
        public bool? SendRawOfParseSettings { get; set; }

        public Task<IResult<ParseSetting>> Execute()
        {
            return Processor.Process<ParseSetting, ICreateParseSettingCommand, CreateParseSettingCommand>(this,
                context => context.CreateParseSetting(this));
        }

        public Task<IResult<ParseSetting>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<CreateParseSettingCommand>(commandJson);

            return Processor.Process<ParseSetting, ICreateParseSettingCommand, CreateParseSettingCommand>(this,
                context => context.CreateParseSetting(command));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<ParseSetting, ICreateParseSettingCommand, CreateParseSettingCommand>(this,
                context => context.CreateParseSetting(this));
        }

        public ICreateParseSettingCommand HostName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return this;

            HostnameOfParseSettings = value;
            return this;
        }

        public ICreateParseSettingCommand Url(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return this;

            UrlOfParseSettings = value;
            return this;
        }

        public ICreateParseSettingCommand SpamCheck(bool value)
        {
            SpamCheckOfParseSettings = value;
            return this;
        }

        public ICreateParseSettingCommand SendRaw(bool value)
        {
            SendRawOfParseSettings = value;
            return this;
        }

        public ICreateParseSettingCommand ByModel(ParseSetting value)
        {
            HostnameOfParseSettings = value.Hostname;
            UrlOfParseSettings = value.Url;
            SpamCheckOfParseSettings = value.SpamCheck;
            SendRawOfParseSettings = value.SendRaw;

            return this;
        }

        public ICreateParseSettingCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator= new CreateParseSettingCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}