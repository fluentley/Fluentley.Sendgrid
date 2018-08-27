using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.Teammates.Core
{
    public interface IApproveTeammateAccessRequestCommand : IContextQuery<IApproveTeammateAccessRequestCommand>

    {
        IApproveTeammateAccessRequestCommand ById(string id);
    }
}