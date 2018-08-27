namespace Fluentley.SendGrid.Operations.EmailOperations.Core
{
    public interface IClickTrackingOption
    {
        IClickTrackingOption Enable(bool value);
        IClickTrackingOption InlcudeInPlainText(bool value);
    }
}