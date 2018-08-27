using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Webhooks.Models;

namespace Fluentley.SendGrid.Operations.Webhooks.Queries
{
    public interface IWebhookParseSettingsListQuery :
        IListMemoryFilterQuery<IWebhookParseSettingsListQuery, WebhookParseSettings>,
        IContextQuery<IWebhookParseSettingsListQuery>
    {
    }

    internal class WebhookParseSettingsListQuery : AbstractListQuery<WebhookParseSettings>,
        IWebhookParseSettingsListQuery,
        IQuery<List<WebhookParseSettings>>
    {
        public WebhookParseSettingsListQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public Task<IResult<List<WebhookParseSettings>>> Execute()
        {
            return QueryProcessor
                .Process<WebhookParseSettings, IWebhookParseSettingsListQuery, WebhookParseSettingsListQuery>(this,
                    context => context.WebhookParseSettings());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<WebhookParseSettings, IWebhookParseSettingsListQuery, WebhookParseSettingsListQuery>(this,
                    context => context.WebhookParseSettings());
        }

        public IWebhookParseSettingsListQuery UseInMemoryQuery(Action<IQueryOption<WebhookParseSettings>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public IWebhookParseSettingsListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}