using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.IpAddresses.Models
{
    public class AddIpResult
    {
        [JsonProperty("ips")]
        public IList<IpAddress> Ips { get; set; }

        [JsonProperty("remaining_ips")]
        public int NumberOfRemainingIps { get; set; }

        [JsonProperty("warmup")]
        public bool Warmup { get; set; }
    }
}