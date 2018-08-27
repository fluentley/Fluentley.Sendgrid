using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.LinkBrandings.Models;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Queries
{
    public interface IBrandedLinkSingleQuery : IContextQuery<IBrandedLinkSingleQuery>

    {
        IBrandedLinkSingleQuery ById(string id);
    }

    internal class BrandedLinkSingleQuery : AbstractSingleQuery<BrandedLink>, IBrandedLinkSingleQuery,
        IQuery<BrandedLink>
    {
        public BrandedLinkSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private string Id { get; set; }

        public IBrandedLinkSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IBrandedLinkSingleQuery ById(string id)
        {
            Id = id;
            return this;
        }

        public Task<IResult<BrandedLink>> Execute()
        {
            return QueryProcessor.Process<BrandedLink, IBrandedLinkSingleQuery, BrandedLinkSingleQuery>(this,
                context => context.BrandedLinkById(Id));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<BrandedLink, IBrandedLinkSingleQuery, BrandedLinkSingleQuery>(this,
                context => context.BrandedLinkById(Id));
        }
    }
}