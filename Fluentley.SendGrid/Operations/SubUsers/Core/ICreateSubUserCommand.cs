using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.SubUsers.Core
{
    public interface ICreateSubUserCommand : IContextQuery<ICreateSubUserCommand>

    {
        ICreateSubUserCommand UserName(string value);
        ICreateSubUserCommand Password(string value);
        ICreateSubUserCommand EmailAddress(string value);
        ICreateSubUserCommand AssignIp(params string[] ips);
    }
}