using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.ApiKeys.Models;

namespace Fluentley.SendGrid.Operations.ApiKeys.Queries
{
    public interface IApiKeyListQuery : IListMemoryFilterQuery<IApiKeyListQuery, ApiKey>,
        IContextQuery<IApiKeyListQuery>
    {
        IApiKeyListQuery LimitResults(int value);
    }

    internal class ApiKeyListQuery : AbstractListQuery<ApiKey>, IApiKeyListQuery, IQuery<List<ApiKey>>
    {
        public ApiKeyListQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public int? Limit { get; set; }

        public IApiKeyListQuery UseInMemoryQuery(Action<IQueryOption<ApiKey>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public IApiKeyListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IApiKeyListQuery LimitResults(int value)
        {
            Limit = value;
            return this;
        }

        public Task<IResult<List<ApiKey>>> Execute()
        {
            return QueryProcessor.Process<ApiKey, IApiKeyListQuery, ApiKeyListQuery>(this,
                context => context.ApiKeys(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<ApiKey, IApiKeyListQuery, ApiKeyListQuery>(this,
                context => context.ApiKeys(this));
        }
    }
}