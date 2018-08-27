using System;
using Fluentley.SendGrid.Common.Extensions;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.IpWarmups.Models
{
    public class IpWarmup
    {
        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonIgnore]
        public DateTime? StartDateInUtc { get; set; }

        [JsonProperty("start_date")]
        internal long? StartDateInUnix => StartDateInUtc?.ToUnixTime();
    }
}