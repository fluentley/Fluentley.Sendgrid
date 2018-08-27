using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SettingMail.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.SettingMail.Commands
{
    public interface IUpdateSpamForwardingSettingCommand : IContextQuery<IUpdateSpamForwardingSettingCommand>

    {
        IUpdateSpamForwardingSettingCommand Model(SpamForwardingSetting value);
        IUpdateSpamForwardingSettingCommand EmailAddress(string value);
        IUpdateSpamForwardingSettingCommand IsEnabled(bool value);
    }

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
    }
}