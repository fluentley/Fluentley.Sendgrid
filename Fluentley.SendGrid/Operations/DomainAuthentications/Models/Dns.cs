using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Models
{
    public class Dns
    {
        [JsonProperty("mail_cname")]
        public MailCname MailCname { get; set; }

        [JsonProperty("spf")]
        public Spf Spf { get; set; }

        [JsonProperty("dkim1")]
        public Dkim Dkim1 { get; set; }

        [JsonProperty("dkim2")]
        public Dkim Dkim2 { get; set; }

        [JsonProperty("mail_server")]
        public Spf MailServer { get; set; }

        [JsonProperty("subdomain_spf")]
        public Spf SubdomainSpf { get; set; }

        [JsonProperty("domain_spf")]
        public Spf DomainSpf { get; set; }

        [JsonProperty("dkim")]
        public Dkim Dkim { get; set; }
    }
}