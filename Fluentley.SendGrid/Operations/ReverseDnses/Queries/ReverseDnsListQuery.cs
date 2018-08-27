using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.ReverseDnses.Core;
using Fluentley.SendGrid.Operations.ReverseDnses.Models;

namespace Fluentley.SendGrid.Operations.ReverseDnses.Queries
{
    internal class ReverseDnsListQuery : AbstractListQuery<ReverseDns>, IReverseDnsListQuery, IQuery<List<ReverseDns>>
    {
        public ReverseDnsListQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal int? PageSize { get; set; }

        internal int? PageIndex { get; set; }

        internal string IpAddress { get; set; }

        public Task<IResult<List<ReverseDns>>> Execute()
        {
            return QueryProcessor.Process<ReverseDns, IReverseDnsListQuery, ReverseDnsListQuery>(this,
                context => context.ReverseDnses(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<ReverseDns, IReverseDnsListQuery, ReverseDnsListQuery>(this,
                context => context.ReverseDnses(this));
        }

        public IReverseDnsListQuery UsePaging(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            return this;
        }

        public IReverseDnsListQuery FilterByIpAddress(string ipAddress)
        {
            IpAddress = ipAddress;
            return this;
        }

        public IReverseDnsListQuery UseInMemoryQuery(Action<IQueryOption<ReverseDns>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public IReverseDnsListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}