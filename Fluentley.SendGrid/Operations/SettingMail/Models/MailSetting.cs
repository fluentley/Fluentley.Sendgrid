using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.SettingMail.Models
{
    public class MailSetting
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}