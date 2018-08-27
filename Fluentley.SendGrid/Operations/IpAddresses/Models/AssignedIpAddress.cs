using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.IpAddresses.Models
{
    public class AssignedIpAddress
    {
        public string Ip { get; set; }

        [JsonProperty("pools")]
        public IList<string> Pools { get; set; }

        [JsonProperty("warmup")]
        public bool IsWarmup { get; set; }

        [JsonProperty("start_date")]
        public int StartDate { get; set; }
    }
}