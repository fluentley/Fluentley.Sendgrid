using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.SettingEnforcedTls.Models
{
    public class EnforcedTls
    {
        [JsonProperty("require_tls")]
        public bool RequireTls { get; set; }

        [JsonProperty("require_valid_cert")]
        public bool RequireValidCert { get; set; }
    }
}