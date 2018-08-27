using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.Teammates.Core
{
    public interface IResendTeammateInviteCommand : IContextQuery<IResendTeammateInviteCommand>

    {
        IResendTeammateInviteCommand ByToken(string value);
    }
}