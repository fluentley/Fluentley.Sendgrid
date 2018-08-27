using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.Campaigns.Models;

namespace Fluentley.SendGrid.Operations.Campaigns.Core
{
    public interface ICreateCampaignCommand : IContextQuery<ICreateCampaignCommand>

    {
        ICreateCampaignCommand ByModel(Campaign campaign);
    }
}