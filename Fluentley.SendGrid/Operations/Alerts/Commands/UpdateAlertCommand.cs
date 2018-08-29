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
    internal class UpdateAlertCommand : AbstractCommand<Alert, UpdateAlertCommand>, IUpdateAlertCommand, ICommand<Alert>
    {
        public UpdateAlertCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("id")]
        internal string IdForAlert { get; set; }

        [JsonProperty("frequency")]
        internal string FrequencyTextForAlert { get; set; }

        [JsonProperty("percentage")]
        internal int? PercentageForAlert { get; set; }

        [JsonProperty("email_to")]
        internal string EmailToForAlert { get; set; }

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
            return Processor.Process<Alert, IUpdateAlertCommand, UpdateAlertCommand>(this,
                context => context.UpdateAlert(this), context =>
                {
                    var validator = new UpdateAlertCommandValidator();
                    return validator.ValidateAsync(this);
                });
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<Alert, IUpdateAlertCommand, UpdateAlertCommand>(this,
                context => context.UpdateAlert(this), context =>
                {
                    var validator = new UpdateAlertCommandValidator();
                    return validator.ValidateAsync(this);
                });
        }

        public IUpdateAlertCommand ByModel(Alert alert)
        {
            IdForAlert = alert.Id;
            EmailToForAlert = alert.EmailTo;
            PercentageForAlert = alert.Percentage;
            FrequencyTextForAlert = alert.FrequencyText;
            return this;
        }

        public IUpdateAlertCommand Id(string value)
        {
            IdForAlert = value;
            return this;
        }

        public IUpdateAlertCommand SendAlertTo(string value)
        {
            EmailToForAlert = value;
            return this;
        }

        public IUpdateAlertCommand AlertFrequency(Frequency value)
        {
            FrequencyForAlert = value;
            return this;
        }

        public IUpdateAlertCommand ThresholdUsagePercentage(int value)
        {
            PercentageForAlert = value;
            return this;
        }

        public IUpdateAlertCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}