using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Models
{
    public class AuthenticatedDomainValidationResult
    {
        [JsonProperty("valid")]
        public bool Valid { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}