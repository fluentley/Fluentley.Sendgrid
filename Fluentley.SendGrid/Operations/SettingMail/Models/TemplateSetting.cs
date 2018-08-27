using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.SettingMail.Models
{
    public class TemplateSetting
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("html_content")]
        public string HtmlContent { get; set; }
    }
}