using System;
using Fluentley.SendGrid.Operations.EmailOperations.Options.MailSettings;
using Fluentley.SendGrid.Processors;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.EmailOperations.Options
{
    public interface IMailSettingsOption
    {
        IMailSettingsOption Bcc(Action<IBccOption> option);
        IMailSettingsOption AllowBypassListManagement(Action<IBypassListManagementOption> option);
        IMailSettingsOption SandboxMode(bool value);
        IMailSettingsOption SpamCheck(Action<ISpamCheckOption> option);
        IMailSettingsOption Footer(Action<IFooterOption> option);
    }

    internal class MailSettingsOption : IMailSettingsOption
    {
        private readonly OptionProcessor _optionProcessor;

        public MailSettingsOption()
        {
            _optionProcessor = new OptionProcessor();
        }

        internal bool IsInSendBoxMode { get; set; }

        [JsonProperty("bypass_list_management")]
        internal BypassListManagementOption BypassListManagementOption { get; set; }

        [JsonProperty("bcc")]
        internal BccOption BccAddress { get; set; } = new BccOption();

        [JsonProperty("footer")]
        internal FooterOption FooterOption { get; set; } = new FooterOption();

        [JsonProperty("spam_check")]
        internal SpamCheckOption SpamCheckOption { get; set; } = new SpamCheckOption();

        public IMailSettingsOption Bcc(Action<IBccOption> option)
        {
            BccAddress = _optionProcessor.Process<IBccOption, BccOption>(option);
            ;
            return this;
        }

        public IMailSettingsOption AllowBypassListManagement(Action<IBypassListManagementOption> option)
        {
            BypassListManagementOption =
                _optionProcessor.Process<IBypassListManagementOption, BypassListManagementOption>(option);
            return this;
        }

        public IMailSettingsOption SandboxMode(bool value)
        {
            IsInSendBoxMode = value;
            return this;
        }

        public IMailSettingsOption SpamCheck(Action<ISpamCheckOption> option)
        {
            SpamCheckOption = _optionProcessor.Process<ISpamCheckOption, SpamCheckOption>(option);
            return this;
        }

        public IMailSettingsOption Footer(Action<IFooterOption> option)
        {
            FooterOption = _optionProcessor.Process<IFooterOption, FooterOption>(option);
            ;
            return this;
        }
    }
}