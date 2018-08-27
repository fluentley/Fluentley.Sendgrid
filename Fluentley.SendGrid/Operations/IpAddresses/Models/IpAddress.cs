using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.IpAddresses.Models
{
    public class IpAddress : Ip
    {
        [JsonProperty("warmup")]
        public bool Warmup { get; set; }

        [JsonProperty("whitelabeled")]
        public bool Whitelabeled { get; set; }

        [JsonProperty("start_date")]
        public long? StartDate { get; set; }

        [JsonProperty("assigned_at")]
        public long? AssignedAt { get; set; }

        [JsonProperty("rdns")]
        public string DnsRecordForIpAddress { get; set; }
    }
}