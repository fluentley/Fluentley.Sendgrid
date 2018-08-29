using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.Alerts.Models;

namespace Fluentley.SendGrid.Operations.Alerts.Core
{
    public interface IDeleteAlertCommand : IContextQuery<IDeleteAlertCommand>

    {
        /// <summary>
        ///     Delete By Alert Id
        /// </summary>
        /// <param name="id">Id of the Alert</param>
        /// <returns></returns>
        IDeleteAlertCommand ById(string id);

        /// <summary>
        ///     Delete By Alert Model
        /// </summary>
        /// <param name="model">Alert Model</param>
        /// <returns></returns>
        IDeleteAlertCommand ByModel(Alert model);
    }
}