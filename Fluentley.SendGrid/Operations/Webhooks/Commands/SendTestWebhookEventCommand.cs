using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Webhooks.Core;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Webhooks.Commands
{
    internal class SendTestWebhookEventCommand : AbstractCommand<string, SendTestWebhookEventCommand>,
        ISendTestWebhookEventCommand, ICommand<string>
    {
        public SendTestWebhookEventCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("url")]
        internal string UrlToSendTestEvent { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, ISendTestWebhookEventCommand, SendTestWebhookEventCommand>(this,
                context => context.SendTestWebhookEvent(this) /*, context =>
                {
                    var validator = new SendTestWebhookEventCommandValidator(context);
                    return validator.ValidateAsync(this);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, ISendTestWebhookEventCommand, SendTestWebhookEventCommand>(this,
                context => context.SendTestWebhookEvent(this) /*, context =>
                {
                    var validator = new SendTestWebhookEventCommandValidator(context);
                    return validator.ValidateAsync(this);
                }*/);
        }

        public ISendTestWebhookEventCommand Url(string value)
        {
            UrlToSendTestEvent = value;
            return this;
        }

        public ISendTestWebhookEventCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}