using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.EmailOperations.Models
{
    public class EmailAddress
    {
        public EmailAddress()
        {
        }

        public EmailAddress(string emailAddress, string name = null)
        {
            Value = emailAddress;
            Name = name;
        }

        [JsonProperty("email")]
        public string Value { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;
    }
}