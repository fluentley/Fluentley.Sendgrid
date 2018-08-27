using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.IpAddresses.Core;
using Fluentley.SendGrid.Operations.IpAddresses.Models;

namespace Fluentley.SendGrid.Operations.IpAddresses.Queries
{
    internal class AssignedIpAddressListQuery : AbstractListQuery<AssignedIpAddress>, IAssignedIpAddressListQuery,
        IQuery<List<AssignedIpAddress>>
    {
        public AssignedIpAddressListQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public IAssignedIpAddressListQuery UseInMemoryQuery(Action<IQueryOption<AssignedIpAddress>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public IAssignedIpAddressListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<IResult<List<AssignedIpAddress>>> Execute()
        {
            return QueryProcessor.Process<AssignedIpAddress, IAssignedIpAddressListQuery, AssignedIpAddressListQuery>(
                this,
                context => context.AssignedIpAddresses());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<AssignedIpAddress, IAssignedIpAddressListQuery, AssignedIpAddressListQuery>(
                    this,
                    context => context.AssignedIpAddresses());
        }
    }
}