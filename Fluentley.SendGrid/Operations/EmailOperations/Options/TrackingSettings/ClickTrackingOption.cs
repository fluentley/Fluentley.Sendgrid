using Fluentley.SendGrid.Operations.EmailOperations.Core;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.EmailOperations.Options.TrackingSettings
{
    internal class ClickTrackingOption : IClickTrackingOption
    {
        [JsonProperty("enable_text")]
        internal bool IsIncludedInPlainText { get; set; }

        [JsonProperty("enable")]
        internal bool IsEnabled { get; set; }

        public IClickTrackingOption Enable(bool value)
        {
            IsEnabled = value;
            return this;
        }

        public IClickTrackingOption InlcudeInPlainText(bool value)
        {
            IsIncludedInPlainText = value;
            return this;
        }
    }
}