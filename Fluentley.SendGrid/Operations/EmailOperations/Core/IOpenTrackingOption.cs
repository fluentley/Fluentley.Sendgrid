namespace Fluentley.SendGrid.Operations.EmailOperations.Core
{
    public interface IOpenTrackingOption
    {
        IOpenTrackingOption Enable(bool value);
        IOpenTrackingOption ReplacementSubstituionTag(string value);
    }
}