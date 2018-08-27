using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.IpAddresses.Core;
using Fluentley.SendGrid.Operations.IpAddresses.Models;

namespace Fluentley.SendGrid.Operations.IpAddresses.Queries
{
    internal class IpAddressSingleQuery : AbstractSingleQuery<IpAddress>, IIpAddressSingleQuery, IQuery<IpAddress>
    {
        public IpAddressSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal string IpAddress { get; set; }

        public IIpAddressSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IIpAddressSingleQuery ByIpAddress(string value)
        {
            IpAddress = value;
            return this;
        }

        public Task<IResult<IpAddress>> Execute()
        {
            return QueryProcessor.Process<IpAddress, IIpAddressSingleQuery, IpAddressSingleQuery>(this,
                context => context.IpAddressByIpAddress(IpAddress));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<IpAddress, IIpAddressSingleQuery, IpAddressSingleQuery>(this,
                context => context.IpAddressByIpAddress(IpAddress));
        }
    }
}