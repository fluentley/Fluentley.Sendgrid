using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Models
{
    public class DomainCnameValidationResult
    {
        [JsonProperty("valid")]
        public bool Valid { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}