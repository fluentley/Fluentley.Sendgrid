using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.IpAddresses.Models
{
    public class RemainingIpAddress
    {
        [JsonProperty("remaining")]
        public int NumberOfRemaining { get; set; }

        [JsonProperty("period")]
        public string Period { get; set; }

        [JsonProperty("price_per_ip")]
        public decimal? PricePerIp { get; set; }
    }
}