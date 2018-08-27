using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.IpPools.Models
{
    public class IpPool
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ips")]
        public List<string> IpAddresses { get; set; }
    }
}