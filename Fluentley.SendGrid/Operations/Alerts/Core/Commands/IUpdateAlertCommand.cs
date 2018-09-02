using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.Alerts.Models;

namespace Fluentley.SendGrid.Operations.Alerts.Core.Commands
{
    public interface IUpdateAlertCommand : IContextQuery<IUpdateAlertCommand>

    {
        /// <summary>
        ///     Update By Alert Model
        /// </summary>
        /// <param name="alert">Alert Model</param>
        /// <returns></returns>
        IUpdateAlertCommand ByModel(Alert alert);

        /// <summary>
        ///     The email address the alert will be sent to.
        /// </summary>
        /// <param name="value">EmailAddress</param>
        /// <returns></returns>
        IUpdateAlertCommand SendAlertTo(string value);

        /// <summary>
        ///     Required for stats_notification. How frequently the alert will be sent..
        /// </summary>
        /// <param name="value">Alert Frequency</param>
        /// <returns></returns>
        IUpdateAlertCommand AlertFrequency(Frequency value);

        /// <summary>
        ///     Required for usage_alert. When this usage threshold is reached, the alert will be sent.
        /// </summary>
        /// <param name="value">Percentage</param>
        /// <returns></returns>
        IUpdateAlertCommand ThresholdUsagePercentage(int value);

        /// <summary>
        ///    Id of the Alert
        /// </summary>
        /// <param name="value">Alert Id <c>[Required]</c></param>
        /// <returns></returns>
        IUpdateAlertCommand Id(string value);
    
}