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
    public interface IPendingTeammateInvitationListQuery :
        IListMemoryFilterQuery<IPendingTeammateInvitationListQuery, PendingTeammateInvitation>,
        IContextQuery<IPendingTeammateInvitationListQuery>
    {
        IPendingTeammateInvitationListQuery UsePaging(int pageIndex, int pageSize);
    }

    internal class PendingTeammateInvitationListQuery : AbstractListQuery<PendingTeammateInvitation>,
        IPendingTeammateInvitationListQuery, IQuery<List<PendingTeammateInvitation>>
    {
        public PendingTeammateInvitationListQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal int? PageSize { get; set; }

        internal int? PageIndex { get; set; }

        public IPendingTeammateInvitationListQuery UsePaging(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            return this;
        }

        public IPendingTeammateInvitationListQuery UseInMemoryQuery(
            Action<IQueryOption<PendingTeammateInvitation>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public IPendingTeammateInvitationListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<IResult<List<PendingTeammateInvitation>>> Execute()
        {
            return QueryProcessor
                .Process<PendingTeammateInvitation, IPendingTeammateInvitationListQuery,
                    PendingTeammateInvitationListQuery>(this,
                    context => context.PendingTeammateInvitations());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<PendingTeammateInvitation, IPendingTeammateInvitationListQuery,
                    PendingTeammateInvitationListQuery>(this,
                    context => context.PendingTeammateInvitations());
        }
    }
}