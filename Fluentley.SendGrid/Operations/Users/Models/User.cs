using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Users.Models
{
    public class User
    {
        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("user_id")]
        public int Id { get; set; }

        public UserAccount UserAccount { get; set; }
        public UserProfile UserProfile { get; set; }
        public UserEmailAddress UserEmailAddress { get; set; }
        public UserCredit UserCredit { get; set; }
    }
}