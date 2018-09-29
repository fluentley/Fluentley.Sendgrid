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
    internal class UpdateSpamCheckSettingCommand : AbstractCommand<SpamCheckSetting, UpdateSpamCheckSettingCommand>,
        IUpdateSpamCheckSettingCommand, ICommand<SpamCheckSetting>
    {
        public UpdateSpamCheckSettingCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("enabled")]
        public bool EnabledForSpamCheckSetting { get; set; }

        [JsonProperty("max_score")]
        public int MaxScoreForSpamCheckSetting { get; set; }

        [JsonProperty("url")]
        public string UrlForSpamCheckSetting { get; set; }

        public Task<IResult<SpamCheckSetting>> Execute()
        {
            return Processor.Process<SpamCheckSetting, IUpdateSpamCheckSettingCommand, UpdateSpamCheckSettingCommand>(
                this,
                context => context.UpdateSpamCheckSetting(this));
        }

        public Task<IResult<SpamCheckSetting>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<UpdateSpamCheckSettingCommand>(commandJson);

            return Processor.Process<SpamCheckSetting, IUpdateSpamCheckSettingCommand, UpdateSpamCheckSettingCommand>(
                this,
                context => context.UpdateSpamCheckSetting(command));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<SpamCheckSetting, IUpdateSpamCheckSettingCommand, UpdateSpamCheckSettingCommand>(this,
                    context => context.UpdateSpamCheckSetting(this));
        }

        public IUpdateSpamCheckSettingCommand ByModel(SpamCheckSetting value)
        {
            MaxScoreForSpamCheckSetting = value.MaxScore;
            EnabledForSpamCheckSetting = value.Enabled;
            UrlForSpamCheckSetting = value.Url;
            return this;
        }

        public IUpdateSpamCheckSettingCommand Url(string value)
        {
            UrlForSpamCheckSetting = value;
            return this;
        }

        public IUpdateSpamCheckSettingCommand MaxScore(int value)
        {
            MaxScoreForSpamCheckSetting = value;
            return this;
        }

        public IUpdateSpamCheckSettingCommand IsEnabled(bool value)
        {
            EnabledForSpamCheckSetting = value;
            return this;
        }

        public IUpdateSpamCheckSettingCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new UpdateSpamCheckSettingCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}