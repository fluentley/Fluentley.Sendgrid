using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.DomainAuthentications.Core;
using Fluentley.SendGrid.Operations.DomainAuthentications.Models;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Queries
{
    internal class AuthenticatedDomainSingleQuery : AbstractSingleQuery<AuthenticatedDomain>,
        IAuthenticatedDomainSingleQuery,
        IQuery<AuthenticatedDomain>
    {
        public AuthenticatedDomainSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private string Id { get; set; }

        public IAuthenticatedDomainSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IAuthenticatedDomainSingleQuery ById(string id)
        {
            Id = id;
            return this;
        }

        public Task<IResult<AuthenticatedDomain>> Execute()
        {
            return QueryProcessor
                .Process<AuthenticatedDomain, IAuthenticatedDomainSingleQuery, AuthenticatedDomainSingleQuery>(this,
                    context => context.AuthenticatedDomainById(Id));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<AuthenticatedDomain, IAuthenticatedDomainSingleQuery, AuthenticatedDomainSingleQuery>(this,
                    context => context.AuthenticatedDomainById(Id));
        }
    }
}