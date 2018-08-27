using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.ReverseDnses.Models
{
    public class User
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }
    }
}