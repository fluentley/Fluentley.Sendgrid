using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.ReverseDnses.Models;

namespace Fluentley.SendGrid.Operations.Teammates.Core
{
    public interface ITeammateAccessRequestListQuery :
        IListMemoryFilterQuery<ITeammateAccessRequestListQuery, TeammateAccessRequest>,
        IContextQuery<ITeammateAccessRequestListQuery>
    {
        ITeammateAccessRequestListQuery UsePaging(int pageIndex, int pageSize);
    }
}