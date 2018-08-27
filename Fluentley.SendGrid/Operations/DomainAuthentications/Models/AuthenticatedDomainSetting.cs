using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Models
{
    public class AuthenticatedDomainSetting
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("custom_spf")]
        public bool CustomSpf { get; set; }

        [JsonProperty("default")]
        public bool Default { get; set; }
    }
}