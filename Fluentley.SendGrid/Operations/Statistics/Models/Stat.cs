using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Statistics.Models
{
    public class Stat
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("metrics")]
        public Metrics Metrics { get; set; }
    }
}