﻿using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Webhooks.Core;
using Fluentley.SendGrid.Operations.Webhooks.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Operations.Webhooks.Validators;
using FluentValidation.Results;

namespace Fluentley.SendGrid.Operations.Webhooks.Commands
{
    internal class UpdateWebHookSettingsCommand : AbstractCommand<WebhookSettings, UpdateWebHookSettingsCommand>,
        IUpdateWebHookSettingsCommand,
        ICommand<WebhookSettings>
    {
        public UpdateWebHookSettingsCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("group_resubscribe")]
        public bool GroupResubscribe { get; set; }

        [JsonProperty("delivered")]
        public bool Delivered { get; set; }

        [JsonProperty("group_unsubscribe")]
        public bool GroupUnsubscribe { get; set; }

        [JsonProperty("spam_report")]
        public bool SpamReport { get; set; }

        [JsonProperty("bounce")]
        public bool Bounce { get; set; }

        [JsonProperty("deferred")]
        public bool Deferred { get; set; }

        [JsonProperty("unsubscribe")]
        public bool Unsubscribe { get; set; }

        [JsonProperty("processed")]
        public bool Processed { get; set; }

        [JsonProperty("open")]
        public bool Open { get; set; }

        [JsonProperty("click")]
        public bool Click { get; set; }

        [JsonProperty("dropped")]
        public bool Dropped { get; set; }

        public Task<IResult<WebhookSettings>> Execute()
        {
            return Processor.Process<WebhookSettings, IUpdateWebHookSettingsCommand, UpdateWebHookSettingsCommand>(
                this, context => context.UpdateWebhookSettings(this));
        }

        public Task<IResult<WebhookSettings>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<UpdateWebHookSettingsCommand>(commandJson);

            return Processor.Process<WebhookSettings, IUpdateWebHookSettingsCommand, UpdateWebHookSettingsCommand>(
                this, context => context.UpdateWebhookSettings(command));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<WebhookSettings, IUpdateWebHookSettingsCommand, UpdateWebHookSettingsCommand>(
                    this, context => context.UpdateWebhookSettings(this));
        }

        public IUpdateWebHookSettingsCommand ByModel(WebhookSettings webhookSettings)
        {
            Url = webhookSettings.Url;
            Enabled = webhookSettings.Enabled;
            Delivered = webhookSettings.Delivered;
            GroupResubscribe = webhookSettings.GroupResubscribe;
            SpamReport = webhookSettings.SpamReport;
            Bounce = webhookSettings.Bounce;
            Deferred = webhookSettings.Deferred;
            Unsubscribe = webhookSettings.Unsubscribe;
            Processed = webhookSettings.Processed;
            Open = webhookSettings.Open;
            Click = webhookSettings.Click;
            Dropped = webhookSettings.Dropped;
            return this;
        }

        public IUpdateWebHookSettingsCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new UpdateWebhookSettingsCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}