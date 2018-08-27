using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Teammates.Models
{
    public class ApproveTeammateRequestResult
    {
        [JsonProperty("scope_group_name")]
        public string ScopeGroupName { get; set; }
    }
}