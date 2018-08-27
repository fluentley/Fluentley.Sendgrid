using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.Alerts.Models;

namespace Fluentley.SendGrid.Operations.Alerts.Core
{
    public interface IAlertListQuery : IListMemoryFilterQuery<IAlertListQuery, Alert>, IContextQuery<IAlertListQuery>
    {
    }
}