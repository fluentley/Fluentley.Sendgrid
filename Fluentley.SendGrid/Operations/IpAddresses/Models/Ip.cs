using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.IpAddresses.Models
{
    public class Ip : IpBase
    {
        [JsonProperty("pools")]
        public IList<string> Pools { get; set; }

        [JsonProperty("subusers")]
        public IList<string> Subusers { get; set; }
    }
}