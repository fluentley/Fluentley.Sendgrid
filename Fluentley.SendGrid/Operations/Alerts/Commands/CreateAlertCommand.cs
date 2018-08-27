using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Alerts.Extensions;
using Fluentley.SendGrid.Operations.Alerts.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Alerts.Commands
{
    public interface ICreateAlertCommand : IContextQuery<ICreateAlertCommand>

    {
        ICreateAlertCommand ByModel(Alert alert);

        ICreateAlertCommand Using(AlertType alertType, string emailTo, Frequency frequency = Frequency.Undefined,
            int? percentage = null);
    }

    internal class CreateAlertCommand : AbstractCommand<Alert, CreateAlertCommand>, ICreateAlertCommand, ICommand<Alert>
    {
        public CreateAlertCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("type")]
        internal string TypeText { get; set; }

        [JsonProperty("email_to")]
        internal string EmailTo { get; set; }

        [JsonProperty("frequency")]
        internal string FrequencyText { get; set; }

        [JsonProperty("percentage")]
        internal int? Percentage { get; set; }

        [JsonIgnore]
        internal AlertType Type
        {
            get
            {
                switch (TypeText)
                {
                    case "stats_notification":
                        return AlertType.StatisticsNotification;
                    case "usage_limit":
                        return AlertType.UsageLimit;

                    default:
                        return AlertType.Undefined;
                }
            }
            set => TypeText = value.ToAlertTypeText();
        }

        [JsonIgnore]
        internal Frequency Frequency
        {
            get
            {
                switch (FrequencyText)
                {
                    case "daily":
                        return Frequency.Daily;
                    case "monthly":
                        return Frequency.Monthly;
                    case "weekly":
                        return Frequency.Weekly;

                    default:
                        return Frequency.Undefined;
                }
            }
            set => FrequencyText = value.ToFrequenctyText();
        }

        public Task<IResult<Alert>> Execute()
        {
            return Processor.Process<Alert, ICreateAlertCommand, CreateAlertCommand>(this,
                context => context.CreateAlert(this) /*, context =>
                {
                    var validator = new CreateAlertCommandValidator();
                    return validator.ValidateAsync(this);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<Alert, ICreateAlertCommand, CreateAlertCommand>(this,
                context => context.CreateAlert(this) /*, context =>
                {
                    var validator = new CreateAlertCommandValidator();
                    return validator.ValidateAsync(this);
                }*/);
        }

        public ICreateAlertCommand ByModel(Alert alert)
        {
            if (alert == null)
                return this;

            TypeText = alert.TypeText;
            EmailTo = alert.EmailTo;
            Percentage = alert.Percentage;
            FrequencyText = alert.FrequencyText;

            return this;
        }

        public ICreateAlertCommand Using(AlertType alertType, string emailTo,
            Frequency frequency = Frequency.Undefined, int? percentage = null)
        {
            Type = alertType;
            EmailTo = emailTo;
            Percentage = percentage;
            Frequency = frequency;

            return this;
        }

        public ICreateAlertCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}