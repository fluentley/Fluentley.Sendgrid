using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.IpPools.Core;
using Fluentley.SendGrid.Operations.IpPools.Models;

namespace Fluentley.SendGrid.Operations.IpPools.Queries
{
    internal class IpPoolSingleQuery : AbstractSingleQuery<IpPool>, IIpPoolSingleQuery, IQuery<IpPool>
    {
        public IpPoolSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private string Name { get; set; }

        public IIpPoolSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IIpPoolSingleQuery ByName(string name)
        {
            Name = name;
            return this;
        }

        public Task<IResult<IpPool>> Execute()
        {
            return QueryProcessor.Process<IpPool, IIpPoolSingleQuery, IpPoolSingleQuery>(this,
                context => context.IpPoolByName(Name));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<IpPool, IIpPoolSingleQuery, IpPoolSingleQuery>(this,
                context => context.IpPoolByName(Name));
            throw new NotImplementedException();
        }
    }
}