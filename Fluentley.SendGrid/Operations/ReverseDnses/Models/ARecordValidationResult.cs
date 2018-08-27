using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.ReverseDnses.Models
{
    public class ARecordValidationResult
    {
        [JsonProperty("valid")]
        public bool Valid { get; set; }

        [JsonProperty("reason")]
        public object Reason { get; set; }
    }
}