using System;
using Fluentley.SendGrid.Common.Extensions;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Common.Models
{
    public class EmailReport
    {
        [JsonProperty("created")]
        internal long CreatedAtUnix { get; set; }

        public DateTime CreatedOnUtc => CreatedAtUnix.EpocTimeToDateTime();

        [JsonProperty("email")]
        public string Value { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}