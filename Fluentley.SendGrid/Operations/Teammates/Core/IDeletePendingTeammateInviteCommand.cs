using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.Teammates.Core
{
    public interface IDeletePendingTeammateInviteCommand : IContextQuery<IDeletePendingTeammateInviteCommand>

    {
        IDeletePendingTeammateInviteCommand ByToken(string value);
    }
}