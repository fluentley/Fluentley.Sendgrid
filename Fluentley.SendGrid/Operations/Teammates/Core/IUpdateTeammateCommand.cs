using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.Teammates.Core
{
    public interface IUpdateTeammateCommand : IContextQuery<IUpdateTeammateCommand>

    {
        IUpdateTeammateCommand IsAdminTeammate(bool value);
        IUpdateTeammateCommand AddScope(params string[] values);
    }
}