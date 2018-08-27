using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.Webhooks.Core
{
    public interface ISendTestWebhookEventCommand : IContextQuery<ISendTestWebhookEventCommand>

    {
        ISendTestWebhookEventCommand Url(string url);
    }
}