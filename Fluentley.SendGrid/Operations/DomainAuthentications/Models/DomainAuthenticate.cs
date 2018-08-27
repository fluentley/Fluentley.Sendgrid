using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Models
{
    public class DomainAuthenticate
    {
        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("subdomain")]
        public string Subdomain { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("ips")]
        public IList<string> Ips { get; set; }

        [JsonProperty("custom_spf")]
        public bool CustomSpf { get; set; }

        [JsonProperty("default")]
        public bool Default { get; set; }

        [JsonProperty("automatic_security")]
        public bool AutomaticSecurity { get; set; }
    }
}