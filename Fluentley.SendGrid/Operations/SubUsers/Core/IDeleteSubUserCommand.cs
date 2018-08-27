using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.SubUsers.Core
{
    public interface IDeleteSubUserCommand : IContextQuery<IDeleteSubUserCommand>

    {
        IDeleteSubUserCommand BySubUserName(string subUserName);
    }
}