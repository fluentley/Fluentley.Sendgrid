using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.Campaigns.Models;

namespace Fluentley.SendGrid.Operations.Campaigns.Core
{
    public interface ICampaignSendCommand : IContextQuery<ICampaignSendCommand>

    {
        ICampaignSendCommand ById(string id);
        ICampaignSendCommand ByModel(Campaign value);
    }
}