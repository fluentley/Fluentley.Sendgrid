using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.DomainAuthentications.Models;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Queries
{
    public interface IAuthenticatedDomainListForSubuserQuery :
        IListMemoryFilterQuery<IAuthenticatedDomainListForSubuserQuery, AuthenticatedDomain>,
        IContextQuery<IAuthenticatedDomainListForSubuserQuery>
    {
    }

    internal class AuthenticatedDomainListForSubuserQuery : AbstractListQuery<AuthenticatedDomain>,
        IAuthenticatedDomainListForSubuserQuery, IQuery<List<AuthenticatedDomain>>
    {
        public AuthenticatedDomainListForSubuserQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public IAuthenticatedDomainListForSubuserQuery UseInMemoryQuery(
            Action<IQueryOption<AuthenticatedDomain>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public IAuthenticatedDomainListForSubuserQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<IResult<List<AuthenticatedDomain>>> Execute()
        {
            return QueryProcessor
                .Process<AuthenticatedDomain, IAuthenticatedDomainListForSubuserQuery,
                    AuthenticatedDomainListForSubuserQuery>(this,
                    context => context.AuthenticatedDomainsForSubUser(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<AuthenticatedDomain, IAuthenticatedDomainListForSubuserQuery,
                    AuthenticatedDomainListForSubuserQuery>(this,
                    context => context.AuthenticatedDomainsForSubUser(this));
        }
    }
}