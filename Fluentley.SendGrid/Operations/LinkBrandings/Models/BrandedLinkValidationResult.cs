using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Models
{
    public class BrandedLinkValidationResult
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("valid")]
        public bool Valid { get; set; }

        [JsonProperty("validation_results")]
        public ValidationResults ValidationResults { get; set; }
    }
}