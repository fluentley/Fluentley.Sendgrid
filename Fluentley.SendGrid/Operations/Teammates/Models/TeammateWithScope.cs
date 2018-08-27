using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Teammates.Models
{
    public class TeammateWithScope : Teammate
    {
        [JsonProperty("scopes")]
        public IList<string> Scopes { get; set; }
    }
}