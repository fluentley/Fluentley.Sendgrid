using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.Webhooks.Models;

namespace Fluentley.SendGrid.Operations.Webhooks.Core
{
    public interface IWebhookParseSettingsListQuery :
        IListMemoryFilterQuery<IWebhookParseSettingsListQuery, WebhookParseSettings>,
        IContextQuery<IWebhookParseSettingsListQuery>
    {
    }
}