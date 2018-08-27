using Fluentley.SendGrid.Operations.EmailOperations.Core;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.EmailOperations.Options.TrackingSettings
{
    internal class OpenTrackingOption : IOpenTrackingOption
    {
        [JsonProperty("substitution_tag")]
        internal string SubstitutionTag { get; set; }

        [JsonProperty("enable")]
        internal bool IsEnabled { get; set; }

        public IOpenTrackingOption Enable(bool value)
        {
            IsEnabled = value;
            return this;
        }

        public IOpenTrackingOption ReplacementSubstituionTag(string value)
        {
            SubstitutionTag = value;
            return this;
        }
    }
}