using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.LinkBrandings.Core;
using Fluentley.SendGrid.Operations.LinkBrandings.Models;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Queries
{
    internal class BrandedLinkForSubuserSingleQuery : AbstractSingleQuery<BrandedLink>,
        IBrandedLinkForSubuserSingleQuery,
        IQuery<BrandedLink>
    {
        public BrandedLinkForSubuserSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private string SubUser { get; set; }

        public IBrandedLinkForSubuserSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IBrandedLinkForSubuserSingleQuery BySubUserName(string subUserName)
        {
            SubUser = subUserName;
            return this;
        }

        public Task<IResult<BrandedLink>> Execute()
        {
            return QueryProcessor
                .Process<BrandedLink, IBrandedLinkForSubuserSingleQuery, BrandedLinkForSubuserSingleQuery>(this,
                    context => context.BrandedLinksForSubuser(SubUser));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<BrandedLink, IBrandedLinkForSubuserSingleQuery, BrandedLinkForSubuserSingleQuery>(this,
                    context => context.BrandedLinksForSubuser(SubUser));
        }
    }
}