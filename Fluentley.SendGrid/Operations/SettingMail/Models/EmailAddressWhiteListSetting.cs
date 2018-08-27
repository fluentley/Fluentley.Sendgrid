using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.SettingMail.Models
{
    public class EmailAddressWhiteListSetting
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("list")]
        public List<string> List { get; set; }
    }
}