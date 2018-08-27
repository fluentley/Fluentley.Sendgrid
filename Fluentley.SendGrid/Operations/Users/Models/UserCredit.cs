using System;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Users.Models
{
    public class UserCredit
    {
        [JsonProperty("remain")]
        public decimal Remain { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("overage")]
        public decimal Overage { get; set; }

        [JsonProperty("used")]
        public decimal Used { get; set; }

        [JsonProperty("last_reset")]
        public DateTime LastReset { get; set; }

        [JsonProperty("next_reset")]
        public DateTime NextReset { get; set; }

        [JsonProperty("reset_frequency")]
        public string ResetFrequency { get; set; }
    }
}