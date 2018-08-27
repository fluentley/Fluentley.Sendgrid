using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.ReverseDnses.Models
{
    public class TeammateAccessRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("scope_group_name")]
        public string ScopeGroupName { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }
    }
}