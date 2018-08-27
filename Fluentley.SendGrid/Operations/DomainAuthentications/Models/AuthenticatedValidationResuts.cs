using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Models
{
    public class AuthenticatedValidationResuts
    {
        [JsonProperty("mail_cname")]
        public AuthenticatedDomainValidationResult MailCname { get; set; }

        [JsonProperty("dkim1")]
        public AuthenticatedDomainValidationResult Dkim1 { get; set; }

        [JsonProperty("dkim2")]
        public AuthenticatedDomainValidationResult Dkim2 { get; set; }

        [JsonProperty("spf")]
        public AuthenticatedDomainValidationResult Spf { get; set; }
    }
}