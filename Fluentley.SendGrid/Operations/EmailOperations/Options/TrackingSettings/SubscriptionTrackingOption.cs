using Fluentley.SendGrid.Operations.EmailOperations.Core;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.EmailOperations.Options.TrackingSettings
{
    internal class SubscriptionTrackingOption : ISubscriptionTrackingOption
    {
        [JsonProperty("enable")]
        internal bool IsEnabled { get; set; }

        [JsonProperty("text")]
        internal string SubscriptionTrackingText { get; set; }

        [JsonProperty("html")]
        internal string SubscriptionTrackingHtml { get; set; }

        [JsonProperty("substitution_tag")]
        internal string SubstitutionTag { get; set; }

        public ISubscriptionTrackingOption Enable(bool value)
        {
            IsEnabled = value;
            return this;
        }

        public ISubscriptionTrackingOption AppendTextWithSubscriptionTracking(string value)
        {
            SubscriptionTrackingText = value;
            return this;
        }

        public ISubscriptionTrackingOption AppendHtmlWithSubscriptionTracking(string value)
        {
            SubscriptionTrackingHtml = value;
            return this;
        }

        public ISubscriptionTrackingOption ReplacementSubstituionTag(string value)
        {
            SubstitutionTag = value;
            return this;
        }
    }
}