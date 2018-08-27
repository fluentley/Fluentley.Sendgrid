using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.Alerts.Models;

namespace Fluentley.SendGrid.Operations.Alerts.Core
{
    public interface IUpdateAlertCommand : IContextQuery<IUpdateAlertCommand>

    {
        IUpdateAlertCommand ByModel(Alert alert);

        IUpdateAlertCommand Using(string id, string emailTo = null, Frequency frequency = Frequency.Undefined,
            int? percentage = null);
    }
}