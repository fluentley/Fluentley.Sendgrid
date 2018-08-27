using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.Users.Core
{
    public interface IUpdateUserPasswordCommand : IContextQuery<IUpdateUserPasswordCommand>

    {
        IUpdateUserPasswordCommand Password(string oldPassword, string newPassword);
    }
}