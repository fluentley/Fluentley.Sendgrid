using System;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.CampaignSchedules.Core;

namespace Fluentley.SendGrid.Operations.Campaigns.Core
{
    public interface ICampaignSingleQuery : IContextQuery<ICampaignSingleQuery>

    {
        ICampaignSingleQuery ById(string id);
        ICampaignSingleQuery EagerLoadCampaignSchedule(Action<ICampaignScheduleSingleQuery> queryAction);
    }
}