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
    internal class UpdateBccSettingCommand : AbstractCommand<BccSetting, UpdateBccSettingCommand>,
        IUpdateBccSettingCommand, ICommand<BccSetting>
    {
        public UpdateBccSettingCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("email")]
        public string EmailForBccSetting { get; set; }

        [JsonProperty("enabled")]
        public bool? EnabledForBccSetting { get; set; }

        public Task<IResult<BccSetting>> Execute()
        {
            return Processor.Process<BccSetting, IUpdateBccSettingCommand, UpdateBccSettingCommand>(this,
                context => context.UpdateBccSetting(this));
        }

        public Task<IResult<BccSetting>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<UpdateBccSettingCommand>(commandJson);

            return Processor.Process<BccSetting, IUpdateBccSettingCommand, UpdateBccSettingCommand>(this,
                context => context.UpdateBccSetting(command));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<BccSetting, IUpdateBccSettingCommand, UpdateBccSettingCommand>(this,
                context => context.UpdateBccSetting(this));
        }

        public IUpdateBccSettingCommand ByModel(BccSetting value)
        {
            EmailForBccSetting = value.Email;
            EnabledForBccSetting = value.Enabled;
            return this;
        }

        public IUpdateBccSettingCommand EmailAddress(string value)
        {
            EmailForBccSetting = value;
            return this;
        }

        public IUpdateBccSettingCommand IsEnabled(bool value)
        {
            EnabledForBccSetting = value;
            return this;
        }

        public IUpdateBccSettingCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new UpdateBccSettingCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}