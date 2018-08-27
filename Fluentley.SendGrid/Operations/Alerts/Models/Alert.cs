using System;
using Fluentley.SendGrid.Common.Extensions;
using Fluentley.SendGrid.Operations.Alerts.Extensions;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Alerts.Models
{
    public class Alert
    {
        [JsonProperty("created_at")]
        internal long CreatedAtUnix { get; set; }

        [JsonProperty("email_to")]
        public string EmailTo { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("percentage")]
        public int? Percentage { get; set; }

        [JsonProperty("type")]
        internal string TypeText { get; set; }

        [JsonProperty("updated_at")]
        internal long UpdatedAtUnix { get; set; }

        public DateTime CreatedOnUtc => CreatedAtUnix.EpocTimeToDateTime();
        public DateTime UpdatedOnUtc => UpdatedAtUnix.EpocTimeToDateTime();

        [JsonProperty("frequency")]
        internal string FrequencyText { get; set; }

        [JsonIgnore]
        public AlertType Type
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
        public Frequency Frequency
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
    }
}