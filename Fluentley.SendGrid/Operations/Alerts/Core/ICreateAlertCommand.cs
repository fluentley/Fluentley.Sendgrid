using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.Alerts.Models;

namespace Fluentley.SendGrid.Operations.Alerts.Core
{
    public interface ICreateAlertCommand : IContextQuery<ICreateAlertCommand>

    {
        /// <summary>
        ///     Create By Alert Model
        /// </summary>
        /// <param name="alert">Alert Model</param>
        /// <returns></returns>
        ICreateAlertCommand ByModel(Alert alert);

        /// <summary>
        ///     The type of alert you want to create.
        /// </summary>
        /// <param name="value">Alert Type <c>[Required]</c></param>
        /// <returns></returns>
        ICreateAlertCommand Type(AlertType value);

        /// <summary>
        ///     The email address the alert will be sent to.
        /// </summary>
        /// <param name="value">EmailAddress <c>[Required]</c></param>
        /// <returns></returns>
        ICreateAlertCommand SendAlertTo(string value);

        /// <summary>
        ///     Required for stats_notification. How frequently the alert will be sent..
        /// </summary>
        /// <param name="value">Alert Frequency</param>
        /// <returns></returns>
        ICreateAlertCommand AlertFrequency(Frequency value);

        /// <summary>
        ///     Required for usage_alert. When this usage threshold is reached, the alert will be sent.
        /// </summary>
        /// <param name="value">Percentage</param>
        /// <returns></returns>
        ICreateAlertCommand ThresholdUsagePercentage(int value);
    }
}