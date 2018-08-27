using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.EmailOperations.Options.TrackingSettings
{
    public interface IGoogleAnalyticsOption
    {
        IGoogleAnalyticsOption Enable(bool value);
        IGoogleAnalyticsOption UtmSource(string value);
        IGoogleAnalyticsOption UtmMedium(string value);
        IGoogleAnalyticsOption UtmTerm(string value);
        IGoogleAnalyticsOption UtmContent(string value);
        IGoogleAnalyticsOption UtmCampaign(string value);
    }

    internal class GoogleAnalyticsOption : IGoogleAnalyticsOption
    {
        [JsonProperty("utm_campaign")]
        internal string CampaignUtm { get; set; }

        [JsonProperty("utm_content")]
        internal string ContentUtm { get; set; }

        [JsonProperty("utm_term")]
        internal string TermUtm { get; set; }

        [JsonProperty("utm_medium")]

        internal string MediumUtm { get; set; }

        [JsonProperty("utm_source")]
        internal string SourceUtm { get; set; }

        [JsonProperty("enable")]
        internal bool IsEnabled { get; set; }

        public IGoogleAnalyticsOption Enable(bool value)
        {
            IsEnabled = value;
            return this;
        }

        public IGoogleAnalyticsOption UtmSource(string value)
        {
            SourceUtm = value;
            return this;
        }

        public IGoogleAnalyticsOption UtmMedium(string value)
        {
            MediumUtm = value;
            return this;
        }

        public IGoogleAnalyticsOption UtmTerm(string value)
        {
            TermUtm = value;
            return this;
        }

        public IGoogleAnalyticsOption UtmContent(string value)
        {
            ContentUtm = value;
            return this;
        }

        public IGoogleAnalyticsOption UtmCampaign(string value)
        {
            CampaignUtm = value;
            return this;
        }
    }
}