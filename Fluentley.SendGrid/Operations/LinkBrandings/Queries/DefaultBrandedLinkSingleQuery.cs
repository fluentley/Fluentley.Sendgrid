using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.LinkBrandings.Models;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Queries
{
    public interface IDefaultBrandedLinkSingleQuery : IContextQuery<IDefaultBrandedLinkSingleQuery>

    {
        IDefaultBrandedLinkSingleQuery FilterByDomainUrl(string domainUrl);
    }

    internal class DefaultBrandedLinkSingleQuery : AbstractSingleQuery<BrandedLink>, IDefaultBrandedLinkSingleQuery,
        IQuery<BrandedLink>
    {
        public DefaultBrandedLinkSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private string DomainUrl { get; set; }

        public IDefaultBrandedLinkSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IDefaultBrandedLinkSingleQuery FilterByDomainUrl(string domainUrl)
        {
            DomainUrl = domainUrl;
            return this;
        }

        public Task<IResult<BrandedLink>> Execute()
        {
            return QueryProcessor.Process<BrandedLink, IDefaultBrandedLinkSingleQuery, DefaultBrandedLinkSingleQuery>(
                this,
                context => context.DefaultBrandedLink(DomainUrl));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<BrandedLink, IDefaultBrandedLinkSingleQuery, DefaultBrandedLinkSingleQuery>(
                    this,
                    context => context.DefaultBrandedLink(DomainUrl));
        }
    }
}