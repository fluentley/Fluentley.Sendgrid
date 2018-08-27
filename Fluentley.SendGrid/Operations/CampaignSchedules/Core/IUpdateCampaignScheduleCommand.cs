using System;
using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.CampaignSchedules.Core
{
    public interface IUpdateCampaignScheduleCommand : IContextQuery<IUpdateCampaignScheduleCommand>

    {
        IUpdateCampaignScheduleCommand CampaignId(string id);
        IUpdateCampaignScheduleCommand ScheduleOnUtc(DateTime value);
    }
}