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
    internal class UpdateTemplateSettingCommand : AbstractCommand<TemplateSetting, UpdateTemplateSettingCommand>,
        IUpdateTemplateSettingCommand, ICommand<TemplateSetting>
    {
        public UpdateTemplateSettingCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("html_content")]
        public string HtmlContentForTemplateSetting { get; set; }

        [JsonProperty("enabled")]
        public bool EnabledForTemplateSetting { get; set; }

        public Task<IResult<TemplateSetting>> Execute()
        {
            return Processor.Process<TemplateSetting, IUpdateTemplateSettingCommand, UpdateTemplateSettingCommand>(
                this,
                context => context.UpdateTemplateSetting(this));
        }

        public Task<IResult<TemplateSetting>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<UpdateTemplateSettingCommand>(commandJson);

            return Processor.Process<TemplateSetting, IUpdateTemplateSettingCommand, UpdateTemplateSettingCommand>(
                this,
                context => context.UpdateTemplateSetting(command));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<TemplateSetting, IUpdateTemplateSettingCommand, UpdateTemplateSettingCommand>(this,
                    context => context.UpdateTemplateSetting(this));
        }

        public IUpdateTemplateSettingCommand ByModel(TemplateSetting value)
        {
            HtmlContentForTemplateSetting = value.HtmlContent;
            EnabledForTemplateSetting = value.Enabled;
            return this;
        }

        public IUpdateTemplateSettingCommand HtmlContent(string value)
        {
            HtmlContentForTemplateSetting = value;
            return this;
        }

        public IUpdateTemplateSettingCommand IsEnabled(bool value)
        {
            EnabledForTemplateSetting = value;
            return this;
        }

        public IUpdateTemplateSettingCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new UpdateTemplateSettingCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}