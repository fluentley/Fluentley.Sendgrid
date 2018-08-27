using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.Campaigns.Models;

namespace Fluentley.SendGrid.Operations.Campaigns.Core
{
    public interface ICampaignListQuery : IListMemoryFilterQuery<ICampaignListQuery, Campaign>,
        IContextQuery<ICampaignListQuery>
    {
        ICampaignListQuery UsePaging(int pageIndex, int pageSize);
    }
}