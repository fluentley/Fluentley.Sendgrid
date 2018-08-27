using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.CampaignSchedules.Core
{
    public interface ICampaignScheduleSingleQuery : IContextQuery<ICampaignScheduleSingleQuery>

    {
        ICampaignScheduleSingleQuery ByCampaignId(string id);
    }
}