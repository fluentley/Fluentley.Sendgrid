using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SettingInboundParse.Core;
using Fluentley.SendGrid.Operations.SettingInboundParse.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.SettingInboundParse.Commands
{
    internal class UpdateParseSettingCommand : AbstractCommand<ParseSetting, UpdateParseSettingCommand>,
        IUpdateParseSettingCommand, ICommand<ParseSetting>
    {
        public UpdateParseSettingCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("hostname")]
        internal string HostnameOfParseSettings { get; set; }

        [JsonProperty("url")]
        public string UrlOfParseSettings { get; set; }

        [JsonProperty("spam_check")]
        public bool SpamCheckOfParseSettings { get; set; }

        [JsonProperty("send_raw")]
        public bool SendRawOfParseSettings { get; set; }

        public Task<IResult<ParseSetting>> Execute()
        {
            return Processor.Process<ParseSetting, IUpdateParseSettingCommand, UpdateParseSettingCommand>(this,
                context => context.UpdateParseSetting(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<ParseSetting, IUpdateParseSettingCommand, UpdateParseSettingCommand>(this,
                context => context.UpdateParseSetting(this));
        }

        public IUpdateParseSettingCommand HostName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return this;

            HostnameOfParseSettings = value;
            return this;
        }

        public IUpdateParseSettingCommand Url(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return this;

            UrlOfParseSettings = value;
            return this;
        }

        public IUpdateParseSettingCommand SpamCheck(bool value)
        {
            SpamCheckOfParseSettings = value;
            return this;
        }

        public IUpdateParseSettingCommand SendRaw(bool value)
        {
            SendRawOfParseSettings = value;
            return this;
        }

        public IUpdateParseSettingCommand ByModel(ParseSetting value)
        {
            HostnameOfParseSettings = value.Hostname;
            UrlOfParseSettings = value.Url;
            SpamCheckOfParseSettings = value.SpamCheck;
            SendRawOfParseSettings = value.SendRaw;

            return this;
        }

        public IUpdateParseSettingCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}