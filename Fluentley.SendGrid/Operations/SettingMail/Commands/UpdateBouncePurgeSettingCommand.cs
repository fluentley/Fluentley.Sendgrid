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
    internal class UpdateBouncePurgeSettingCommand :
        AbstractCommand<BouncePurgeSetting, UpdateBouncePurgeSettingCommand>,
        IUpdateBouncePurgeSettingCommand, ICommand<BouncePurgeSetting>
    {
        public UpdateBouncePurgeSettingCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("soft_bounces")]
        public int? SoftBounces { get; set; }

        [JsonProperty("hard_bounces")]
        public int? HardBounces { get; set; }

        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        public Task<IResult<BouncePurgeSetting>> Execute()
        {
            return Processor
                .Process<BouncePurgeSetting, IUpdateBouncePurgeSettingCommand, UpdateBouncePurgeSettingCommand>(this,
                    context => context.UpdateBouncePurgeSetting(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<BouncePurgeSetting, IUpdateBouncePurgeSettingCommand, UpdateBouncePurgeSettingCommand>(this,
                    context => context.UpdateBouncePurgeSetting(this));
        }

        public IUpdateBouncePurgeSettingCommand ByModel(BouncePurgeSetting value)
        {
            HardBounces = value.HardBounces;
            SoftBounces = value.SoftBounces;
            Enabled = value.Enabled;
            return this;
        }

        public IUpdateBouncePurgeSettingCommand NumberOfHardBounces(int value)
        {
            HardBounces = value;
            return this;
        }

        public IUpdateBouncePurgeSettingCommand NumberOfSoftBounces(int value)
        {
            SoftBounces = value;
            return this;
        }

        public IUpdateBouncePurgeSettingCommand IsEnabled(bool value)
        {
            Enabled = value;
            return this;
        }

        public IUpdateBouncePurgeSettingCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new UpdateBouncePurgeSettingCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}