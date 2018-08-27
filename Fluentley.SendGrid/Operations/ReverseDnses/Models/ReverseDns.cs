using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.ReverseDnses.Models
{
    public class ReverseDns
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("rdns")]
        public string Rdns { get; set; }

        [JsonProperty("users")]
        public IList<User> Users { get; set; }

        [JsonProperty("subdomain")]
        public string Subdomain { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("valid")]
        public bool Valid { get; set; }

        [JsonProperty("legacy")]
        public bool Legacy { get; set; }

        [JsonProperty("a_record")]
        public ARecord ARecord { get; set; }
    }
}