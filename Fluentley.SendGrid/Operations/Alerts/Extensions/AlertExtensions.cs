using System;
using Fluentley.SendGrid.Operations.Alerts.Models;

namespace Fluentley.SendGrid.Operations.Alerts.Extensions
{
    internal static class AlertExtensions
    {
        public static string ToFrequenctyText(this Frequency frequency)
        {
            switch (frequency)
            {
                case Frequency.Undefined:
                    return string.Empty;
                case Frequency.Daily:

                    return "daily";
                case Frequency.Weekly:
                    return "weekly";
                case Frequency.Monthly:
                    return "monthly";
                default:
                    throw new ArgumentOutOfRangeException(nameof(frequency), frequency, null);
            }
        }

        public static string ToAlertTypeText(this AlertType type)
        {
            switch (type)
            {
                case AlertType.Undefined:
                    return string.Empty;
                case AlertType.UsageLimit:
                    return "usage_limit";
                case AlertType.StatisticsNotification:
                    return "stats_notification";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}