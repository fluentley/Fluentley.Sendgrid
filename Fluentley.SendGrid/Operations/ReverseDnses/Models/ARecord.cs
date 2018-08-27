using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.ReverseDnses.Models
{
    public class ARecord
    {
        [JsonProperty("valid")]
        public bool Valid { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }
    }
}