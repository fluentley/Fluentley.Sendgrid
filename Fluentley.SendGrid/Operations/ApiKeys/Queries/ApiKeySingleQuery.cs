using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.ApiKeys.Core;
using Fluentley.SendGrid.Operations.ApiKeys.Models;

namespace Fluentley.SendGrid.Operations.ApiKeys.Queries
{
    internal class ApiKeySingleQuery : AbstractSingleQuery<ApiKey>, IApiKeySingleQuery, IQuery<ApiKey>
    {
        public ApiKeySingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private string Id { get; set; }

        public IApiKeySingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IApiKeySingleQuery ById(string id)
        {
            Id = id;
            return this;
        }

        public Task<IResult<ApiKey>> Execute()
        {
            return QueryProcessor.Process<ApiKey, IApiKeySingleQuery, ApiKeySingleQuery>(this,
                context => context.ApiKeyById(Id));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<ApiKey, IApiKeySingleQuery, ApiKeySingleQuery>(this,
                context => context.ApiKeyById(Id));
        }
    }
}