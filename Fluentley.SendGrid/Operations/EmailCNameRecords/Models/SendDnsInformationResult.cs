using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.EmailCNameRecords.Models
{
    public class SendDnsInformationResult
    {
        [JsonProperty("uuid")]
        public string Uuid { get; set; }
    }
}