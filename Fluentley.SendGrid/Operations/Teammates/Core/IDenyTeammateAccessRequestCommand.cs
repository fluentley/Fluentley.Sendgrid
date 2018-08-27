using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.Alerts.Models;

namespace Fluentley.SendGrid.Operations.Teammates.Core
{
    public interface IDenyTeammateAccessRequestCommand : IContextQuery<IDenyTeammateAccessRequestCommand>

    {
        IDenyTeammateAccessRequestCommand ById(string id);
        IDenyTeammateAccessRequestCommand ByModel(Alert model);
    }
}