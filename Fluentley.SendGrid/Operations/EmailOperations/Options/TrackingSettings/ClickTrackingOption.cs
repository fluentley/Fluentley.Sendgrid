using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.EmailOperations.Options.TrackingSettings
{
    public interface IClickTrackingOption
    {
        IClickTrackingOption Enable(bool value);
        IClickTrackingOption InlcudeInPlainText(bool value);
    }

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