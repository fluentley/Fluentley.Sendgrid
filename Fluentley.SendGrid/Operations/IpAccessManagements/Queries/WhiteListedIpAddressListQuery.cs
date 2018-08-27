using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.IpAccessManagements.Core;
using Fluentley.SendGrid.Operations.IpAccessManagements.Models;

namespace Fluentley.SendGrid.Operations.IpAccessManagements.Queries
{
    internal class WhiteListedIpAddressListQuery : AbstractListQuery<WhiteListedIpAddress>,
        IWhiteListedIpAddressListQuery, IQuery<List<WhiteListedIpAddress>>
    {
        public WhiteListedIpAddressListQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public int? Limit { get; set; }

        public Task<IResult<List<WhiteListedIpAddress>>> Execute()
        {
            return QueryProcessor
                .Process<WhiteListedIpAddress, IWhiteListedIpAddressListQuery, WhiteListedIpAddressListQuery>(this,
                    context => context.WhiteListedIpAddresses());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<WhiteListedIpAddress, IWhiteListedIpAddressListQuery, WhiteListedIpAddressListQuery>(this,
                    context => context.WhiteListedIpAddresses());
        }

        public IWhiteListedIpAddressListQuery UseInMemoryQuery(Action<IQueryOption<WhiteListedIpAddress>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public IWhiteListedIpAddressListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}