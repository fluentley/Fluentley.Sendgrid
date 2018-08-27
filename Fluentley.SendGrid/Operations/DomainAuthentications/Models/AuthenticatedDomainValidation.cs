using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Models
{
    public class AuthenticatedDomainValidation
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("valid")]
        public bool Valid { get; set; }

        [JsonProperty("validation_resuts")]
        public AuthenticatedValidationResuts ValidationResuts { get; set; }
    }
}