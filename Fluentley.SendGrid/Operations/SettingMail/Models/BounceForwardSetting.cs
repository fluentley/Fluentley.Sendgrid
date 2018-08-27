using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.SettingMail.Models
{
    public class BounceForwardSetting
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}