using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.Alerts.Models;

namespace Fluentley.SendGrid.Operations.Alerts.Core
{
    public interface ICreateAlertCommand : IContextQuery<ICreateAlertCommand>

    {
        ICreateAlertCommand ByModel(Alert alert);

        ICreateAlertCommand Using(AlertType alertType, string emailTo, Frequency frequency = Frequency.Undefined,
            int? percentage = null);
    }
}