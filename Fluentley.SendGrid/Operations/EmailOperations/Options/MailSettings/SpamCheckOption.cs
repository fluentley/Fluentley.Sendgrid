using Fluentley.SendGrid.Operations.EmailOperations.Core;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.EmailOperations.Options.MailSettings
{
    internal class SpamCheckOption : ISpamCheckOption
    {
        [JsonProperty("post_to_url")]
        internal string PostToUrl { get; set; }

        [JsonProperty("threshold")]
        internal int TresholdRate { get; set; }

        [JsonProperty("enable")]
        internal bool IsEnabled { get; set; }

        public ISpamCheckOption Enable(bool value)
        {
            IsEnabled = value;
            return this;
        }

        public ISpamCheckOption Treshold(int value)
        {
            TresholdRate = value;
            return this;
        }

        public ISpamCheckOption PostReportToUrl(string value)
        {
            PostToUrl = value;
            return this;
        }
    }
}