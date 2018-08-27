using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Statistics.Models
{
    public class Metrics
    {
        [JsonProperty("blocks")]
        public int Blocks { get; set; }

        [JsonProperty("bounce_drops")]
        public int BounceDrops { get; set; }

        [JsonProperty("bounces")]
        public int Bounces { get; set; }

        [JsonProperty("clicks")]
        public int Clicks { get; set; }

        [JsonProperty("deferred")]
        public int Deferred { get; set; }

        [JsonProperty("delivered")]
        public int Delivered { get; set; }

        [JsonProperty("invalid_emails")]
        public int InvalidEmails { get; set; }

        [JsonProperty("opens")]
        public int Opens { get; set; }

        [JsonProperty("processed")]
        public int Processed { get; set; }

        [JsonProperty("requests")]
        public int Requests { get; set; }

        [JsonProperty("spam_report_drops")]
        public int SpamReportDrops { get; set; }

        [JsonProperty("spam_reports")]
        public int SpamReports { get; set; }

        [JsonProperty("unique_clicks")]
        public int UniqueClicks { get; set; }

        [JsonProperty("unique_opens")]
        public int UniqueOpens { get; set; }

        [JsonProperty("unsubscribe_drops")]
        public int UnsubscribeDrops { get; set; }

        [JsonProperty("unsubscribes")]
        public int Unsubscribes { get; set; }
    }
}