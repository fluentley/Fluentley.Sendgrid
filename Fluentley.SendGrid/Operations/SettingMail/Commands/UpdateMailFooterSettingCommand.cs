using System;
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
    internal class UpdateMailFooterSettingCommand : AbstractCommand<MailFooterSetting, UpdateMailFooterSettingCommand>,
        IUpdateMailFooterSettingCommand, ICommand<MailFooterSetting>
    {
        public UpdateMailFooterSettingCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("enabled")]
        public bool EnabledForMailForwardingSetting { get; set; }

        [JsonProperty("html_content")]
        public string HtmlContentForMailForwardingSetting { get; set; }

        [JsonProperty("plain_content")]
        public string PlainContentForMailForwardingSetting { get; set; }

        public Task<IResult<MailFooterSetting>> Execute()
        {
            return Processor
                .Process<MailFooterSetting, IUpdateMailFooterSettingCommand, UpdateMailFooterSettingCommand>(this,
                    context => context.UpdateMailFooterSetting(this));
        }

        public Task<IResult<MailFooterSetting>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<UpdateMailFooterSettingCommand>(commandJson);

            return Processor
                .Process<MailFooterSetting, IUpdateMailFooterSettingCommand, UpdateMailFooterSettingCommand>(this,
                    context => context.UpdateMailFooterSetting(command));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<MailFooterSetting, IUpdateMailFooterSettingCommand, UpdateMailFooterSettingCommand>(this,
                    context => context.UpdateMailFooterSetting(this));
        }

        public IUpdateMailFooterSettingCommand ByModel(MailFooterSetting value)
        {
            EnabledForMailForwardingSetting = value.Enabled;
            HtmlContentForMailForwardingSetting = value.HtmlContent;
            PlainContentForMailForwardingSetting = value.PlainContent;
            return this;
        }

        public IUpdateMailFooterSettingCommand HtmlContent(string value)
        {
            HtmlContentForMailForwardingSetting = value;
            return this;
        }

        public IUpdateMailFooterSettingCommand PlainContent(string value)
        {
            PlainContentForMailForwardingSetting = value;
            return this;
        }

        public IUpdateMailFooterSettingCommand IsEnabled(bool value)
        {
            EnabledForMailForwardingSetting = value;
            return this;
        }

        public IUpdateMailFooterSettingCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new UpdateMailFooterSettingCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}