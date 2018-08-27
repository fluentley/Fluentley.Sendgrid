using System;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.Campaigns.Models;

namespace Fluentley.SendGrid.Operations.Campaigns.Core
{
    public interface IUpdateCampaignCommand : IContextQuery<IUpdateCampaignCommand>

    {
        IUpdateCampaignCommand ByModel(Campaign campaign);
        IUpdateCampaignCommand Id(string id);
        IUpdateCampaignCommand ChangeScheduledTimeInUtc(DateTime time);
    }
}