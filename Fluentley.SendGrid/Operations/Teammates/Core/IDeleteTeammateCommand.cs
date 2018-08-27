using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.Teammates.Models;

namespace Fluentley.SendGrid.Operations.Teammates.Core
{
    public interface IDeleteTeammateCommand : IContextQuery<IDeleteTeammateCommand>

    {
        IDeleteTeammateCommand ByUserName(string userName);
        IDeleteTeammateCommand ByModel(Teammate model);
    }
}