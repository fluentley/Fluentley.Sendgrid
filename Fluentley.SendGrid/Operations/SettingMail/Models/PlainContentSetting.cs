using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.SettingMail.Models
{
    public class PlainContentSetting
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
}