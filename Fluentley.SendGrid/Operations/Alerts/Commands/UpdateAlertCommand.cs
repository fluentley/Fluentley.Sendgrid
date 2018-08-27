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
    public interface IUpdateAlertCommand : IContextQuery<IUpdateAlertCommand>

    {
        IUpdateAlertCommand ByModel(Alert alert);

        IUpdateAlertCommand Using(string id, string emailTo = null, Frequency frequency = Frequency.Undefined,
            int? percentage = null);
    }

    internal class UpdateAlertCommand : AbstractCommand<Alert, UpdateAlertCommand>, IUpdateAlertCommand, ICommand<Alert>
    {
        public UpdateAlertCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("id")]
        internal string Id { get; set; }

        [JsonProperty("frequency")]
        internal string FrequencyText { get; set; }

        [JsonProperty("percentage")]
        internal int? Percentage { get; set; }

        [JsonProperty("email_to")]
        internal string EmailTo { get; set; }

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
            return Processor.Process<Alert, IUpdateAlertCommand, UpdateAlertCommand>(this,
                context => context.UpdateAlert(this) /*, context =>
                {
                    var validator = new UpdateAlertCommandValidator(context);
                    return validator.ValidateAsync(this);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<Alert, IUpdateAlertCommand, UpdateAlertCommand>(this,
                context => context.UpdateAlert(this) /*, context =>
                {
                    var validator = new UpdateAlertCommandValidator(context);
                    return validator.ValidateAsync(this);
                }*/);
        }

        public IUpdateAlertCommand ByModel(Alert alert)
        {
            Id = alert.Id;
            EmailTo = alert.EmailTo;
            Percentage = alert.Percentage;
            FrequencyText = alert.FrequencyText;
            return this;
        }

        public IUpdateAlertCommand Using(string id, string emailTo = null, Frequency frequency = Frequency.Undefined,
            int? percentage = null)
        {
            Id = id;
            EmailTo = emailTo;
            Percentage = percentage;
            Frequency = frequency;

            return this;
        }

        public IUpdateAlertCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}