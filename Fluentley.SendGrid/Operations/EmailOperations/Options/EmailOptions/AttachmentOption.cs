using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.EmailOperations.Options.EmailOptions
{
    public interface IAttachmentOption
    {
        IAttachmentOption Content(string value);
        IAttachmentOption Type(string value);
        IAttachmentOption FileName(string value);
        IAttachmentOption Disposition(string value);
        IAttachmentOption ContentId(string value);
    }

    internal class AttachmentOption : IAttachmentOption
    {
        [JsonProperty("content")]
        internal string AttachmentContent { get; set; }

        [JsonProperty("type")]

        internal string AttachmentType { get; set; }

        [JsonProperty("filename")]
        internal string AttachmentFileName { get; set; }

        [JsonProperty("disposition")]

        internal string AttachmentDisposition { get; set; }

        [JsonProperty("content_id")]
        internal string AttachmentContentId { get; set; }

        public IAttachmentOption Content(string value)
        {
            AttachmentContent = value;
            return this;
        }

        public IAttachmentOption Type(string value)
        {
            AttachmentType = value;
            return this;
        }

        public IAttachmentOption FileName(string value)
        {
            AttachmentFileName = value;
            return this;
        }

        public IAttachmentOption Disposition(string value)
        {
            AttachmentDisposition = value;
            return this;
        }

        public IAttachmentOption ContentId(string value)
        {
            AttachmentContentId = value;
            return this;
        }
    }
}