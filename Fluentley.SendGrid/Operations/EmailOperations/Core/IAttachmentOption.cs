namespace Fluentley.SendGrid.Operations.EmailOperations.Core
{
    public interface IAttachmentOption
    {
        IAttachmentOption Content(string value);
        IAttachmentOption Type(string value);
        IAttachmentOption FileName(string value);
        IAttachmentOption Disposition(string value);
        IAttachmentOption ContentId(string value);
    }
}