using Fluentley.SendGrid.Operations.EmailOperations.Core;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.EmailOperations.Options.MailSettings
{
    internal class FooterOption : IFooterOption
    {
        [JsonProperty("text")]
        internal string FooterCotentText { get; set; }

        [JsonProperty("html")]
        internal string FooterCotentHtml { get; set; }

        [JsonProperty("enable")]
        internal bool IsEnabled { get; set; }

        public IFooterOption ContentText(string value)
        {
            FooterCotentText = value;
            return this;
        }

        public IFooterOption ContentHtml(string value)
        {
            FooterCotentHtml = value;
            return this;
        }

        public IFooterOption Enable(bool value)
        {
            IsEnabled = value;
            return this;
        }
    }
}