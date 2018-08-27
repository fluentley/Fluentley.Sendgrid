using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.ReverseDnses.Models
{
    public class ReverseDnsValidationResult
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("valid")]
        public bool Valid { get; set; }

        [JsonProperty("validation_results")]
        public ReverseDnsValidationResultList ValidationResults { get; set; }
    }
}