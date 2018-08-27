using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.ReverseDnses.Models
{
    public class ReverseDnsValidationResultList
    {
        [JsonProperty("a_record")]
        public ARecord ARecord { get; set; }
    }
}