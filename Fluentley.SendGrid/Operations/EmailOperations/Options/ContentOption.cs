using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.EmailOperations.Options
{
    public interface IContentOption
    {
        IContentOption Type(string value);
        IContentOption Value(string value);
    }

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