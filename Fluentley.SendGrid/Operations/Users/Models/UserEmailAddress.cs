using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Users.Models
{
    public class UserEmailAddress
    {
        [JsonProperty("email")]
        public string EmailAddress { get; set; }
    }
}