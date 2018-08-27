using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Teammates.Models;

namespace Fluentley.SendGrid.Operations.Teammates.Queries
{
    public interface ITeammateListQuery : IListMemoryFilterQuery<ITeammateListQuery, Teammate>,
        IContextQuery<ITeammateListQuery>
    {
        ITeammateListQuery UsePaging(int pageIndex, int pageSize);
    }

    internal class TeammateListQuery : AbstractListQuery<Teammate>, ITeammateListQuery, IQuery<List<Teammate>>
    {
        public TeammateListQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal int? PageSize { get; set; }

        internal int? PageIndex { get; set; }

        public Task<IResult<List<Teammate>>> Execute()
        {
            return QueryProcessor.Process<Teammate, ITeammateListQuery, TeammateListQuery>(this,
                context => context.Teammates(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<Teammate, ITeammateListQuery, TeammateListQuery>(this,
                context => context.Teammates(this));
        }

        public ITeammateListQuery UsePaging(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            return this;
        }

        public ITeammateListQuery UseInMemoryQuery(Action<IQueryOption<Teammate>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public ITeammateListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}