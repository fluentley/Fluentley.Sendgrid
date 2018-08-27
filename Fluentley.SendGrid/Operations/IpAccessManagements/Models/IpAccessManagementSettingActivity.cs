using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.IpAccessManagements.Models
{
    public class IpAccessManagementSettingActivity
    {
        [JsonProperty("allowed")]
        public bool Allowed { get; set; }

        [JsonProperty("auth_method")]
        public string AuthMethod { get; set; }

        [JsonProperty("first_at")]
        public long FirstAtUnix { get; set; }

        [JsonProperty("ip")]
        public string IpAddress { get; set; }

        [JsonProperty("last_at")]
        public long LastAtUnix { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }
    }
}