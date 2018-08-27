using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Webhooks.Models
{
    public class WebhookSettings
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("group_resubscribe")]
        public bool GroupResubscribe { get; set; }

        [JsonProperty("delivered")]
        public bool Delivered { get; set; }

        [JsonProperty("group_unsubscribe")]
        public bool GroupUnsubscribe { get; set; }

        [JsonProperty("spam_report")]
        public bool SpamReport { get; set; }

        [JsonProperty("bounce")]
        public bool Bounce { get; set; }

        [JsonProperty("deferred")]
        public bool Deferred { get; set; }

        [JsonProperty("unsubscribe")]
        public bool Unsubscribe { get; set; }

        [JsonProperty("processed")]
        public bool Processed { get; set; }

        [JsonProperty("open")]
        public bool Open { get; set; }

        [JsonProperty("click")]
        public bool Click { get; set; }

        [JsonProperty("dropped")]
        public bool Dropped { get; set; }
    }
}