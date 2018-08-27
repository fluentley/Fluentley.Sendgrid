using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.IpAccessManagements.Models
{
    public class WhiteListedIpAddress
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("ip")]
        public string IpAddress { get; set; }

        [JsonProperty("created_at")]
        public int CreatedAtUnix { get; set; }

        [JsonProperty("updated_at")]
        public int UpdatedAtUnix { get; set; }
    }
}