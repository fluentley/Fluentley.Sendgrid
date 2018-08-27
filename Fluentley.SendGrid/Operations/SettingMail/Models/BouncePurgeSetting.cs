using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.SettingMail.Models
{
    public class BouncePurgeSetting
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("soft_bounces")]
        public int? SoftBounces { get; set; }

        [JsonProperty("hard_bounces")]
        public int? HardBounces { get; set; }
    }
}