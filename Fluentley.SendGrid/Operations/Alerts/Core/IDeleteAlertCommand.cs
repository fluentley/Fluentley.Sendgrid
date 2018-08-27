using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.Alerts.Models;

namespace Fluentley.SendGrid.Operations.Alerts.Core
{
    public interface IDeleteAlertCommand : IContextQuery<IDeleteAlertCommand>

    {
        IDeleteAlertCommand ById(string id);
        IDeleteAlertCommand ByModel(Alert model);
    }
}