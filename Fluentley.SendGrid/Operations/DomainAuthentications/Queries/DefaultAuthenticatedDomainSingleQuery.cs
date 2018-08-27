using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.DomainAuthentications.Models;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Queries
{
    public interface IDefaultAuthenticatedDomainSingleQuery : IContextQuery<IDefaultAuthenticatedDomainSingleQuery>

    {
    }

    internal class DefaultAuthenticatedDomainSingleQuery : AbstractSingleQuery<AuthenticatedDomain>,
        IDefaultAuthenticatedDomainSingleQuery,
        IQuery<AuthenticatedDomain>
    {
        public DefaultAuthenticatedDomainSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public IDefaultAuthenticatedDomainSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<IResult<AuthenticatedDomain>> Execute()
        {
            return QueryProcessor
                .Process<AuthenticatedDomain, IDefaultAuthenticatedDomainSingleQuery,
                    DefaultAuthenticatedDomainSingleQuery>(this,
                    context => context.DefaultAuthenticatedDomainByDomain());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<AuthenticatedDomain, IDefaultAuthenticatedDomainSingleQuery,
                    DefaultAuthenticatedDomainSingleQuery>(this,
                    context => context.DefaultAuthenticatedDomainByDomain());
        }
    }
}