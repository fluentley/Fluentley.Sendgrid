using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Webhooks.Models
{
    public class WebhookParseMetrics
    {
        [JsonProperty("received")]
        public int Received { get; set; }
    }
}