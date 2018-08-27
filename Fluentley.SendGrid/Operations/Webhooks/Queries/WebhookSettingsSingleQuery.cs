using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Webhooks.Models;

namespace Fluentley.SendGrid.Operations.Webhooks.Queries
{
    public interface IWebhookSettingsSingleQuery : IContextQuery<IWebhookSettingsSingleQuery>

    {
    }

    internal class WebhookSettingsSingleQuery : AbstractSingleQuery<WebhookSettings>,
        IWebhookSettingsSingleQuery, IQuery<WebhookSettings>
    {
        public WebhookSettingsSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public Task<IResult<WebhookSettings>> Execute()
        {
            return QueryProcessor
                .Process<WebhookSettings, IWebhookSettingsSingleQuery, WebhookSettingsSingleQuery>(this,
                    context => context.WebhookSettings());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<WebhookSettings, IWebhookSettingsSingleQuery, WebhookSettingsSingleQuery>(this,
                    context => context.WebhookSettings());
        }

        public IWebhookSettingsSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}