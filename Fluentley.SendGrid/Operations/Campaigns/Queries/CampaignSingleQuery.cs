using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Campaigns.Models;
using Fluentley.SendGrid.Operations.CampaignSchedules.Queries;

namespace Fluentley.SendGrid.Operations.Campaigns.Queries
{
    public interface ICampaignSingleQuery : IContextQuery<ICampaignSingleQuery>

    {
        ICampaignSingleQuery ById(string id);
        ICampaignSingleQuery EagerLoadCampaignSchedule(Action<ICampaignScheduleSingleQuery> queryAction);
    }

    internal class CampaignSingleQuery : AbstractSingleQuery<Campaign>, ICampaignSingleQuery, IQuery<Campaign>
    {
        public CampaignSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal string Id { get; set; }

        internal CampaignScheduleSingleQuery CampaignScheduleSingleQuery { get; set; }

        public ICampaignSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public ICampaignSingleQuery ById(string id)
        {
            Id = id;
            return this;
        }

        public ICampaignSingleQuery EagerLoadCampaignSchedule(Action<ICampaignScheduleSingleQuery> queryAction = null)
        {
            CampaignScheduleSingleQuery =
                OptionProcessor.Process<ICampaignScheduleSingleQuery, CampaignScheduleSingleQuery>(queryAction);
            return this;
        }

        public async Task<IResult<Campaign>> Execute()
        {
            var campaignSingleQueryResult =
                await QueryProcessor.Process<Campaign, ICampaignSingleQuery, CampaignSingleQuery>(this,
                    context => context.CampaignById(Id));

            if (campaignSingleQueryResult.IsSuccess && campaignSingleQueryResult.Data != null)
                if (CampaignScheduleSingleQuery != null)
                {
                    CampaignScheduleSingleQuery
                        .UseContextOption(ContextOptionAction)
                        .ByCampaignId(Id);

                    var campaignScheduleResult = await CampaignScheduleSingleQuery.Execute();

                    if (campaignScheduleResult.IsSuccess)
                        campaignSingleQueryResult.Data.CampaignSchedule = campaignScheduleResult.Data;
                }

            return campaignSingleQueryResult;
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<Campaign, ICampaignSingleQuery, CampaignSingleQuery>(this,
                context => context.CampaignById(Id));
        }
    }
}