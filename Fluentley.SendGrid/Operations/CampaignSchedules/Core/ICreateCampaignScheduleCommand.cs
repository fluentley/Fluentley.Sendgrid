using System;
using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.CampaignSchedules.Core
{
    public interface ICreateCampaignScheduleCommand : IContextQuery<ICreateCampaignScheduleCommand>

    {
        ICreateCampaignScheduleCommand CampaignId(string id);
        ICreateCampaignScheduleCommand ScheduleOnUtc(DateTime value);
    }
}