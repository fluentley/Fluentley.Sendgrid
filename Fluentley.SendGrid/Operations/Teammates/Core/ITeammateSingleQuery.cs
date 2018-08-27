using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.Teammates.Core
{
    public interface ITeammateSingleQuery : IContextQuery<ITeammateSingleQuery>

    {
        ITeammateSingleQuery ByUserName(string value);
    }
}