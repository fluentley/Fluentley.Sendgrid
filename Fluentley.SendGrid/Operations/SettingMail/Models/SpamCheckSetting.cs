using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.SettingMail.Models
{
    public class SpamCheckSetting
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("max_score")]
        public int MaxScore { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}