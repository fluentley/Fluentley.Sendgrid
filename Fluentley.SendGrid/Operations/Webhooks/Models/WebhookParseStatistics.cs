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
}