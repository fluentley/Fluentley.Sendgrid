namespace Fluentley.SendGrid.Operations.EmailOperations.Core
{
    public interface ISubscriptionTrackingOption
    {
        ISubscriptionTrackingOption Enable(bool value);
        ISubscriptionTrackingOption AppendTextWithSubscriptionTracking(string value);
        ISubscriptionTrackingOption AppendHtmlWithSubscriptionTracking(string value);
        ISubscriptionTrackingOption ReplacementSubstituionTag(string value);
    }
}