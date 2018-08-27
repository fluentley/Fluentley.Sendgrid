using System.Collections.Generic;
using Fluentley.SendGrid.Operations.Statistics.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Webhooks.Models
{
    public class WebhookParseStatistics
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("stats")]
        public IList<Stat> Stats { get; set; }
    }

    public class WebhookParseMetrics
    {
        [JsonProperty("received")]
        public int Received { get; set; }
    }

    public class WebhookParseStat
    {
        [JsonProperty("metrics")]
        public Metrics Metrics { get; set; }
    }
}