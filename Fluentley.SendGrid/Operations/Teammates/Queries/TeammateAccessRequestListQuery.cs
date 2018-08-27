using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.ReverseDnses.Models;
using Fluentley.SendGrid.Operations.Teammates.Core;

namespace Fluentley.SendGrid.Operations.Teammates.Queries
{
    internal class TeammateAccessRequestListQuery : AbstractListQuery<TeammateAccessRequest>,
        ITeammateAccessRequestListQuery, IQuery<List<TeammateAccessRequest>>
    {
        public TeammateAccessRequestListQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal int? PageSize { get; set; }

        internal int? PageIndex { get; set; }

        public Task<IResult<List<TeammateAccessRequest>>> Execute()
        {
            return QueryProcessor
                .Process<TeammateAccessRequest, ITeammateAccessRequestListQuery, TeammateAccessRequestListQuery>(this,
                    context => context.TeammateAccessRequests(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<TeammateAccessRequest, ITeammateAccessRequestListQuery, TeammateAccessRequestListQuery>(this,
                    context => context.TeammateAccessRequests(this));
        }

        public ITeammateAccessRequestListQuery UsePaging(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            return this;
        }

        public ITeammateAccessRequestListQuery UseInMemoryQuery(Action<IQueryOption<TeammateAccessRequest>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public ITeammateAccessRequestListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}