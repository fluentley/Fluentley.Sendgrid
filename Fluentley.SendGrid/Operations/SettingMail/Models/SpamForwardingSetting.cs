using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.SettingMail.Models
{
    public class SpamForwardingSetting
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
}