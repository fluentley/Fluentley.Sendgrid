using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.CampaignSchedules.Core
{
    public interface IDeleteCampaignScheduleCommand : IContextQuery<IDeleteCampaignScheduleCommand>

    {
        IDeleteCampaignScheduleCommand ById(string id);
    }
}