using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.DomainAuthentications.Core;
using Fluentley.SendGrid.Operations.DomainAuthentications.Models;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Queries
{
    internal class AuthenticatedDomainListQuery : AbstractListQuery<AuthenticatedDomain>, IAuthenticatedDomainListQuery,
        IQuery<List<AuthenticatedDomain>>
    {
        public AuthenticatedDomainListQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public int? PageSize { get; set; }

        public int? PageIndex { get; set; }

        public bool? ShouldExcludeSubUsers { get; set; }

        public string UserName { get; set; }

        public string AuthenticatedDomain { get; set; }

        public IAuthenticatedDomainListQuery UseInMemoryQuery(Action<IQueryOption<AuthenticatedDomain>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public IAuthenticatedDomainListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IAuthenticatedDomainListQuery ExcludeSubusers(bool value)
        {
            ShouldExcludeSubUsers = value;
            return this;
        }

        public IAuthenticatedDomainListQuery UsePaging(int pageIndex, int pageSize)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            return this;
        }

        public IAuthenticatedDomainListQuery AssociatedUserName(string subUserName)
        {
            UserName = subUserName;
            return this;
        }

        public IAuthenticatedDomainListQuery Domain(string domain)
        {
            AuthenticatedDomain = domain;
            return this;
        }

        public Task<IResult<List<AuthenticatedDomain>>> Execute()
        {
            return QueryProcessor
                .Process<AuthenticatedDomain, IAuthenticatedDomainListQuery, AuthenticatedDomainListQuery>(this,
                    context => context.AuthenticatedDomains(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<AuthenticatedDomain, IAuthenticatedDomainListQuery, AuthenticatedDomainListQuery>(this,
                    context => context.AuthenticatedDomains(this));
        }
    }
}