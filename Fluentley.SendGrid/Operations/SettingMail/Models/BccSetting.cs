using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.SettingMail.Models
{
    public class BccSetting
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
}