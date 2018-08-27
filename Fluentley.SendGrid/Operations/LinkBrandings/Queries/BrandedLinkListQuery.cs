using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.LinkBrandings.Models;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Queries
{
    public interface IBrandedLinkListQuery : IListMemoryFilterQuery<IBrandedLinkListQuery, BrandedLink>,
        IContextQuery<IBrandedLinkListQuery>
    {
        IBrandedLinkListQuery LimitResults(int value);
    }

    internal class BrandedLinkListQuery : AbstractListQuery<BrandedLink>, IBrandedLinkListQuery,
        IQuery<List<BrandedLink>>
    {
        public BrandedLinkListQuery(string defailtApiKey) : base(defailtApiKey)
        {
        }

        internal int? Limit { get; set; }

        public IBrandedLinkListQuery UseInMemoryQuery(Action<IQueryOption<BrandedLink>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public IBrandedLinkListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IBrandedLinkListQuery LimitResults(int value)
        {
            Limit = value;
            return this;
        }

        public Task<IResult<List<BrandedLink>>> Execute()
        {
            return QueryProcessor.Process<BrandedLink, IBrandedLinkListQuery, BrandedLinkListQuery>(this,
                context => context.BrandedLinks(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<BrandedLink, IBrandedLinkListQuery, BrandedLinkListQuery>(this,
                context => context.BrandedLinks(this));
        }
    }
}