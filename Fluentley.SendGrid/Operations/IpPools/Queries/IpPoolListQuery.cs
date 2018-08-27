using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.IpPools.Core;
using Fluentley.SendGrid.Operations.IpPools.Models;

namespace Fluentley.SendGrid.Operations.IpPools.Queries
{
    internal class IpPoolListQuery : AbstractListQuery<IpPool>, IIpPoolListQuery, IQuery<List<IpPool>>
    {
        public IpPoolListQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public IIpPoolListQuery UseInMemoryQuery(Action<IQueryOption<IpPool>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public IIpPoolListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<IResult<List<IpPool>>> Execute()
        {
            return QueryProcessor.Process<IpPool, IIpPoolListQuery, IpPoolListQuery>(this,
                context => context.IpPools());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<IpPool, IIpPoolListQuery, IpPoolListQuery>(this,
                context => context.IpPools());
        }
    }
}