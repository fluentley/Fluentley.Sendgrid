using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.IpAddresses.Models;

namespace Fluentley.SendGrid.Operations.IpAddresses.Queries
{
    public interface IRemainingIpAddressListQuery :
        IListMemoryFilterQuery<IRemainingIpAddressListQuery, RemainingIpAddress>,
        IContextQuery<IRemainingIpAddressListQuery>
    {
    }

    internal class RemainingIpAddressListQuery : AbstractListQuery<RemainingIpAddress>, IRemainingIpAddressListQuery,
        IQuery<List<RemainingIpAddress>>
    {
        public RemainingIpAddressListQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public Task<IResult<List<RemainingIpAddress>>> Execute()
        {
            return QueryProcessor
                .Process<RemainingIpAddress, IRemainingIpAddressListQuery, RemainingIpAddressListQuery>(this,
                    context => context.RemainingIpAddresses());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<RemainingIpAddress, IRemainingIpAddressListQuery, RemainingIpAddressListQuery>(this,
                    context => context.RemainingIpAddresses());
        }

        public IRemainingIpAddressListQuery UseInMemoryQuery(Action<IQueryOption<RemainingIpAddress>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public IRemainingIpAddressListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}