using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.Teammates.Models;

namespace Fluentley.SendGrid.Operations.Teammates.Core
{
    public interface IPendingTeammateInvitationListQuery :
        IListMemoryFilterQuery<IPendingTeammateInvitationListQuery, PendingTeammateInvitation>,
        IContextQuery<IPendingTeammateInvitationListQuery>
    {
        IPendingTeammateInvitationListQuery UsePaging(int pageIndex, int pageSize);
    }
}