using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.SubUsers.Models;

namespace Fluentley.SendGrid.Operations.SubUsers.Core
{
    public interface IUpdateSubUserCommand : IContextQuery<IUpdateSubUserCommand>

    {
        IUpdateSubUserCommand ByModel(SubUser subUser);
    }
}