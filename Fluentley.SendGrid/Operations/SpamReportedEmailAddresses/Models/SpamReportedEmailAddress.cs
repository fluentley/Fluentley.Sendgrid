using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.SpamReportedEmailAddresses.Models
{
    public class SpamReportedEmailAddress
    {
        [JsonProperty("created")]
        public int Created { get; set; }

        [JsonProperty("email")]
        public string Value { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }
    }
}