using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.IpAddresses.Models
{
    public class IpBase
    {
        [JsonProperty("ip")]
        public string IpAddress { get; set; }
    }
}