using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.Teammates.Core
{
    public interface IInviteTeammateCommand : IContextQuery<IInviteTeammateCommand>

    {
        IInviteTeammateCommand EmailAddress(string value);
        IInviteTeammateCommand IsAdminTeammate(bool value);
        IInviteTeammateCommand AddScope(params string[] values);
    }
}