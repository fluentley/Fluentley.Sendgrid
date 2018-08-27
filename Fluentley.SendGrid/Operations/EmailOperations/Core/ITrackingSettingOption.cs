using System;

namespace Fluentley.SendGrid.Operations.EmailOperations.Core
{
    public interface ITrackingSettingOption
    {
        ITrackingSettingOption ClickTracking(Action<IClickTrackingOption> option);
        ITrackingSettingOption OpenTracking(Action<IOpenTrackingOption> option);
        ITrackingSettingOption SubscriptionTracking(Action<ISubscriptionTrackingOption> option);
        ITrackingSettingOption GoogleAnalytics(Action<IGoogleAnalyticsOption> option);
    }
}