using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.SubUsers.Core
{
    public interface IEnableOrDisableSubUserCommand : IContextQuery<IEnableOrDisableSubUserCommand>

    {
        IEnableOrDisableSubUserCommand Disable(string subUserName, bool value);
    }
}