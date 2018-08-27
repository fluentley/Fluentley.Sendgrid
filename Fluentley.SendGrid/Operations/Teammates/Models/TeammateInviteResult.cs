using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Teammates.Models
{
    public class TeammateInviteResult
    {
        [JsonProperty("pending_id")]
        public string PendingId { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("scopes")]
        public IList<string> Scopes { get; set; }

        [JsonProperty("is_admin")]
        public bool IsAdmin { get; set; }
    }
}