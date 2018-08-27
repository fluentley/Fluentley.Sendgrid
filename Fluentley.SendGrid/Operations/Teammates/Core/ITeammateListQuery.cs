using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.Teammates.Models;

namespace Fluentley.SendGrid.Operations.Teammates.Core
{
    public interface ITeammateListQuery : IListMemoryFilterQuery<ITeammateListQuery, Teammate>,
        IContextQuery<ITeammateListQuery>
    {
        ITeammateListQuery UsePaging(int pageIndex, int pageSize);
    }
}