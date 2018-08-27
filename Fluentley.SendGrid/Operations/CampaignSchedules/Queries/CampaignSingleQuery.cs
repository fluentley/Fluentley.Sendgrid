using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.CampaignSchedules.Models;

namespace Fluentley.SendGrid.Operations.CampaignSchedules.Queries
{
    public interface ICampaignScheduleSingleQuery : IContextQuery<ICampaignScheduleSingleQuery>

    {
        ICampaignScheduleSingleQuery ByCampaignId(string id);
    }

    internal class CampaignScheduleSingleQuery : AbstractSingleQuery<CampaignSchedule>, ICampaignScheduleSingleQuery,
        IQuery<CampaignSchedule>

    {
        public CampaignScheduleSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private string CampaignId { get; set; }

        public ICampaignScheduleSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public ICampaignScheduleSingleQuery ByCampaignId(string id)
        {
            CampaignId = id;
            return this;
        }

        public Task<IResult<CampaignSchedule>> Execute()
        {
            return QueryProcessor.Process<CampaignSchedule, ICampaignScheduleSingleQuery, CampaignScheduleSingleQuery>(
                this,
                context => context.CampaignScheduleByCampaignId(CampaignId));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<CampaignSchedule, ICampaignScheduleSingleQuery, CampaignScheduleSingleQuery>(
                    this,
                    context => context.CampaignScheduleByCampaignId(CampaignId));
        }
    }
}