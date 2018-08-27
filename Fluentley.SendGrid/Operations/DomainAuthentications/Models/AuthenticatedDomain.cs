using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Models
{
    public class AuthenticatedDomain : AuthenticatedDomainSetting
    {
        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("subdomain")]
        public string Subdomain { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("ips")]
        public IList<string> Ips { get; set; }

        [JsonProperty("legacy")]
        public bool Legacy { get; set; }

        [JsonProperty("automatic_security")]
        public bool AutomaticSecurity { get; set; }

        [JsonProperty("valid")]
        public bool Valid { get; set; }

        [JsonProperty("dns")]
        public Dns Dns { get; set; }
    }
}