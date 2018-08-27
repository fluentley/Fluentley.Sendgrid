using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.Campaigns.Models;

namespace Fluentley.SendGrid.Operations.Campaigns.Core
{
    public interface IDeleteCampaignCommand : IContextQuery<IDeleteCampaignCommand>

    {
        IDeleteCampaignCommand ById(string id);
        IDeleteCampaignCommand ByModel(Campaign model);
    }
}