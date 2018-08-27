using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.Webhooks.Models;

namespace Fluentley.SendGrid.Operations.Webhooks.Core
{
    public interface IUpdateWebHookSettingsCommand : IContextQuery<IUpdateWebHookSettingsCommand>

    {
        IUpdateWebHookSettingsCommand ByModel(WebhookSettings webhookSettings);
    }
}