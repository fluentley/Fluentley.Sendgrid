using Fluentley.SendGrid.Operations.Statistics.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Webhooks.Models
{
    public class WebhookParseStat
    {
        [JsonProperty("metrics")]
        public Metrics Metrics { get; set; }
    }
}