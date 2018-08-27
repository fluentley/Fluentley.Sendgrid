using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.IpWarmups.Core;
using Fluentley.SendGrid.Operations.IpWarmups.Models;

namespace Fluentley.SendGrid.Operations.IpWarmups.Queries
{
    internal class IpWarmupListQuery : AbstractListQuery<IpWarmup>, IIpWarmupListQuery, IQuery<List<IpWarmup>>
    {
        public IpWarmupListQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public IIpWarmupListQuery UseInMemoryQuery(Action<IQueryOption<IpWarmup>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public IIpWarmupListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<IResult<List<IpWarmup>>> Execute()
        {
            return QueryProcessor.Process<IpWarmup, IIpWarmupListQuery, IpWarmupListQuery>(this,
                context => context.IpWarmups());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<IpWarmup, IIpWarmupListQuery, IpWarmupListQuery>(this,
                context => context.IpWarmups());
        }
    }
}