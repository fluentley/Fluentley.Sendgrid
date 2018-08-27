using Fluentley.SendGrid.Operations.EmailOperations.Core;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.EmailOperations.Options
{
    internal class ContentOption : IContentOption
    {
        [JsonProperty("value")]
        internal string ContentValue { get; set; }

        [JsonProperty("type")]
        internal string ContentType { get; set; }

        public IContentOption Type(string value)
        {
            ContentType = value;
            return this;
        }

        public IContentOption Value(string value)
        {
            ContentValue = value;
            return this;
        }
    }
}