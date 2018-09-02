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
    internal class UpdateBounceForwardSettingCommand :
        AbstractCommand<BounceForwardSetting, UpdateBounceForwardSettingCommand>,
        IUpdateBounceForwardSettingCommand, ICommand<BounceForwardSetting>
    {
        public UpdateBounceForwardSettingCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        public Task<IResult<BounceForwardSetting>> Execute()
        {
            return Processor
                .Process<BounceForwardSetting, IUpdateBounceForwardSettingCommand, UpdateBounceForwardSettingCommand>(
                    this,
                    context => context.UpdateBounceForwardSetting(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<BounceForwardSetting, IUpdateBounceForwardSettingCommand, UpdateBounceForwardSettingCommand>(
                    this,
                    context => context.UpdateBounceForwardSetting(this));
        }

        public IUpdateBounceForwardSettingCommand ByModel(BounceForwardSetting value)
        {
            Email = value.Email;
            Enabled = value.Enabled;
            return this;
        }

        public IUpdateBounceForwardSettingCommand EmailAddress(string value)
        {
            Email = value;
            return this;
        }

        public IUpdateBounceForwardSettingCommand IsEnabled(bool value)
        {
            Enabled = value;
            return this;
        }

        public IUpdateBounceForwardSettingCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new UpdateBounceForwardSettingCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}