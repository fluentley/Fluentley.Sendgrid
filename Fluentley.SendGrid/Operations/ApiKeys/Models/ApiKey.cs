using System.Collections.Generic;
using System.Linq;
using Fluentley.SendGrid.Operations.ApiKeys.Extensions;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.ApiKeys.Models
{
    public class ApiKey
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("api_key_id")]
        public string Id { get; internal set; }

        [JsonProperty("api_key")]
        public string AccessKey { get; internal set; }

        [JsonProperty("scopes")]
        internal IList<string> StringScopes { get; set; }

        [JsonIgnore]
        public List<Scope> Scopes
        {
            get { return StringScopes?.Select(x => x.ConvertToScope())?.ToList(); }
            set { StringScopes = value?.Select(x => x.DisplayName())?.ToList(); }
        }
    }
}