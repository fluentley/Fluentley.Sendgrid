using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.Alerts.Core.Queries
{
    public interface IAlertSingleQuery : IContextQuery<IAlertSingleQuery>

    {
        /// <summary>
        ///     The ID of the alert you would like to retrieve.
        /// </summary>
        /// <param name="id">Id of the Alert [Required]</param>
        /// <returns></returns>
        IAlertSingleQuery ById(string id);
    }
}