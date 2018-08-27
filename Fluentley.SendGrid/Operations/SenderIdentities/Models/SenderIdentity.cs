using Fluentley.SendGrid.Operations.EmailOperations.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.SenderIdentities.Models
{
    public class SenderIdentity
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("from")]
        public EmailAddress From { get; set; }

        [JsonProperty("reply_to")]
        public EmailAddress ReplyTo { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("address_2")]
        public string Address2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("verified")]
        public bool? Verified { get; set; }

        [JsonProperty("updated_at")]
        public int UpdatedAt { get; set; }

        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty("locked")]
        public bool? Locked { get; set; }
    }
}