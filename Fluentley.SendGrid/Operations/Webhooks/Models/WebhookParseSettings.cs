using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Webhooks.Models
{
    public class WebhookParseSettings
    {
        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("spam_check")]
        public bool SpamCheck { get; set; }

        [JsonProperty("send_raw")]
        public bool SendRaw { get; set; }
    }
}