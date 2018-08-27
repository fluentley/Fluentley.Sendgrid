using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Campaigns.Core;
using Fluentley.SendGrid.Operations.Campaigns.Models;

namespace Fluentley.SendGrid.Operations.Campaigns.Queries
{
    internal class CampaignListQuery : AbstractListQuery<Campaign>, ICampaignListQuery, IQuery<List<Campaign>>
    {
        public CampaignListQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal int? PageSize { get; set; }

        internal int? PageIndex { get; set; }

        public ICampaignListQuery UsePaging(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            return this;
        }

        public ICampaignListQuery UseInMemoryQuery(Action<IQueryOption<Campaign>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public ICampaignListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<IResult<List<Campaign>>> Execute()
        {
            return QueryProcessor.Process<Campaign, ICampaignListQuery, CampaignListQuery>(this,
                context => context.Campaigns(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<Campaign, ICampaignListQuery, CampaignListQuery>(this,
                context => context.Campaigns(this));
        }
    }
}