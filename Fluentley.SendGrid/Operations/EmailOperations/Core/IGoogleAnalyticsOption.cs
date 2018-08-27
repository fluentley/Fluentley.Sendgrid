namespace Fluentley.SendGrid.Operations.EmailOperations.Core
{
    public interface IGoogleAnalyticsOption
    {
        IGoogleAnalyticsOption Enable(bool value);
        IGoogleAnalyticsOption UtmSource(string value);
        IGoogleAnalyticsOption UtmMedium(string value);
        IGoogleAnalyticsOption UtmTerm(string value);
        IGoogleAnalyticsOption UtmContent(string value);
        IGoogleAnalyticsOption UtmCampaign(string value);
    }
}