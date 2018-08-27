using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.Alerts.Core
{
    public interface IAlertSingleQuery : IContextQuery<IAlertSingleQuery>

    {
        IAlertSingleQuery ById(string id);
    }
}