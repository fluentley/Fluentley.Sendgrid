using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.Reputations.Models;

namespace Fluentley.SendGrid.Operations.Reputations.Core
{
    public interface IReputationListQuery : IListMemoryFilterQuery<IReputationListQuery, Reputation>,
        IContextQuery<IReputationListQuery>
    {
        IReputationListQuery AddSubUser(params string[] values);
    }
}