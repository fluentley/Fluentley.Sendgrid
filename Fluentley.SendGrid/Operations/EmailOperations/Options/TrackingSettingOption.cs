using System;
using Fluentley.SendGrid.Operations.EmailOperations.Options.TrackingSettings;
using Fluentley.SendGrid.Processors;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.EmailOperations.Options
{
    public interface ITrackingSettingOption
    {
        ITrackingSettingOption ClickTracking(Action<IClickTrackingOption> option);
        ITrackingSettingOption OpenTracking(Action<IOpenTrackingOption> option);
        ITrackingSettingOption SubscriptionTracking(Action<ISubscriptionTrackingOption> option);
        ITrackingSettingOption GoogleAnalytics(Action<IGoogleAnalyticsOption> option);
    }

    internal class TrackingSettingOption : ITrackingSettingOption
    {
        private readonly OptionProcessor _optionProcessor;

        public TrackingSettingOption()
        {
            _optionProcessor = new OptionProcessor();
        }

        [JsonProperty("click_tracking")]
        internal ClickTrackingOption ClickTrackingOption { get; set; }

        [JsonProperty("open_tracking")]
        internal OpenTrackingOption OpenTrackingOption { get; set; }

        [JsonProperty("subscription_tracking")]
        internal SubscriptionTrackingOption SubscriptionTrackingOption { get; set; }

        [JsonProperty("ganalytics")]
        internal GoogleAnalyticsOption GoogleAnalyticsOption { get; set; }

        public ITrackingSettingOption ClickTracking(Action<IClickTrackingOption> option)
        {
            ClickTrackingOption = _optionProcessor.Process<IClickTrackingOption, ClickTrackingOption>(option);
            return this;
        }

        public ITrackingSettingOption OpenTracking(Action<IOpenTrackingOption> option)
        {
            OpenTrackingOption = _optionProcessor.Process<IOpenTrackingOption, OpenTrackingOption>(option);
            return this;
        }

        public ITrackingSettingOption SubscriptionTracking(Action<ISubscriptionTrackingOption> option)
        {
            SubscriptionTrackingOption =
                _optionProcessor.Process<ISubscriptionTrackingOption, SubscriptionTrackingOption>(option);
            return this;
        }

        public ITrackingSettingOption GoogleAnalytics(Action<IGoogleAnalyticsOption> option)
        {
            GoogleAnalyticsOption = _optionProcessor.Process<IGoogleAnalyticsOption, GoogleAnalyticsOption>(option);
            ;
            return this;
        }
    }
}