using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Alerts.Core;
using Fluentley.SendGrid.Operations.Alerts.Extensions;
using Fluentley.SendGrid.Operations.Alerts.Models;
using Fluentley.SendGrid.Operations.Alerts.Validators;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Alerts.Commands
{
    internal class CreateAlertCommand : AbstractCommand<Alert, CreateAlertCommand>, ICreateAlertCommand, ICommand<Alert>
    {
        public CreateAlertCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("type")]
        internal string TypeTextForAlert { get; set; }

        [JsonProperty("email_to")]
        internal string EmailToForAlert { get; set; }

        [JsonProperty("frequency")]
        internal string FrequencyTextForAlert { get; set; }

        [JsonProperty("percentage")]
        internal int? PercentageForAlert { get; set; }

        [JsonIgnore]
        internal AlertType TypeForAlert
        {
            get
            {
                switch (TypeTextForAlert)
                {
                    case "stats_notification":
                        return AlertType.StatisticsNotification;
                    case "usage_limit":
                        return AlertType.UsageLimit;

                    default:
                        return AlertType.Undefined;
                }
            }
            set => TypeTextForAlert = value.ToAlertTypeText();
        }

        [JsonIgnore]
        internal Frequency FrequencyForAlert
        {
            get
            {
                switch (FrequencyTextForAlert)
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
            set => FrequencyTextForAlert = value.ToFrequenctyText();
        }

        public Task<IResult<Alert>> Execute()
        {
            return Processor.Process<Alert, ICreateAlertCommand, CreateAlertCommand>(this,
                context => context.CreateAlert(this), context =>
                {
                    var validator = new CreateAlertCommandValidator();
                    return validator.ValidateAsync(this);
                });
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<Alert, ICreateAlertCommand, CreateAlertCommand>(this,
                context => context.CreateAlert(this), context =>
                {
                    var validator = new CreateAlertCommandValidator();
                    return validator.ValidateAsync(this);
                });
        }

        public ICreateAlertCommand ByModel(Alert alert)
        {
            if (alert == null)
                return this;

            TypeTextForAlert = alert.TypeText;
            EmailToForAlert = alert.EmailTo;
            PercentageForAlert = alert.Percentage;
            FrequencyTextForAlert = alert.FrequencyText;

            return this;
        }

        public ICreateAlertCommand Type(AlertType value)
        {
            TypeForAlert = value;
            return this;
        }

        public ICreateAlertCommand SendAlertTo(string value)
        {
            EmailToForAlert = value;
            return this;
        }

        public ICreateAlertCommand AlertFrequency(Frequency value)
        {
            FrequencyForAlert = value;
            return this;
        }

        public ICreateAlertCommand ThresholdUsagePercentage(int value)
        {
            PercentageForAlert = value;
            return this;
        }

        public ICreateAlertCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}