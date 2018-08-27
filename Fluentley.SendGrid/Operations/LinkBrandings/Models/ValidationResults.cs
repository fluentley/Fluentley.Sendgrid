using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Models
{
    public class ValidationResults
    {
        [JsonProperty("domain_cname")]
        public DomainCnameValidationResult DomainCname { get; set; }

        [JsonProperty("owner_cname")]
        public OwnerCnameValidationResult OwnerCname { get; set; }
    }
}