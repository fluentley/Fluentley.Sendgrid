using Fluentley.SendGrid.Operations.EmailOperations.Core;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.EmailOperations.Options.MailSettings
{
    internal class BccOption : IBccOption
    {
        [JsonProperty("enable")]
        internal bool IsEnabled { get; set; }

        [JsonProperty("email")]
        internal string EmailAddress { get; set; }

        public IBccOption Enable(bool value)
        {
            IsEnabled = value;
            return this;
        }

        public IBccOption EmaiLAddress(string value)
        {
            EmailAddress = value;
            return this;
        }
    }
}