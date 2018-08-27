using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.MonitorSettings.Models
{
    public class MonitorSetting
    {
        [JsonProperty("email")]
        public string EmailAddress { get; set; }

        [JsonProperty("frequency")]
        public int Frequency { get; set; }
    }
}