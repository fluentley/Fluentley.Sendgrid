using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Models
{
    public class BrandedLink
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("subdomain")]
        public string Subdomain { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("default")]
        public bool Default { get; set; }

        [JsonProperty("valid")]
        public bool Valid { get; set; }

        [JsonProperty("legacy")]
        public bool Legacy { get; set; }

        [JsonProperty("dns")]
        public Dns Dns { get; set; }
    }
}