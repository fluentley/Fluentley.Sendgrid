using Fluentley.SendGrid.Operations.Users.Extensions;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Users.Models
{
    public class UserAccount
    {
        [JsonProperty("reputation")]
        public int Reputation { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonIgnore]
        public AccountType AccountType
        {
            get
            {
                switch (Type)
                {
                    case "free":
                        return AccountType.Free;
                    case "paid":
                        return AccountType.Paid;

                    default:
                        return AccountType.Undefined;
                }
            }
            set => Type = value.ToAccountType();
        }
    }
}