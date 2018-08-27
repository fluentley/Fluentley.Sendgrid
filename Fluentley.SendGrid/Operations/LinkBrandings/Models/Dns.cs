using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Models
{
    public class Dns
    {
        [JsonProperty("domain_cname")]
        public DomainCname DomainCname { get; set; }

        [JsonProperty("owner_cname")]
        public OwnerCname OwnerCname { get; set; }
    }
}