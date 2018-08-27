using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Reputations.Models
{
    public class Reputation
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("reputation")]
        public double ReputationRate { get; set; }
    }
}