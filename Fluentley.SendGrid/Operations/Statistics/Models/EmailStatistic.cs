using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Statistics.Models
{
    public class EmailStatistic
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("stats")]
        public IList<Stat> Stats { get; set; }
    }
}