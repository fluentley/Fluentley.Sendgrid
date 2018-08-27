using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SenderIdentities.Models;

namespace Fluentley.SendGrid.Operations.SenderIdentities.Queries
{
    public interface ISenderIdentityListQuery : IListMemoryFilterQuery<ISenderIdentityListQuery, SenderIdentity>,
        IContextQuery<ISenderIdentityListQuery>
    {
    }

    internal class SenderIdentityListQuery : AbstractListQuery<SenderIdentity>, ISenderIdentityListQuery,
        IQuery<List<SenderIdentity>>
    {
        public SenderIdentityListQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public Task<IResult<List<SenderIdentity>>> Execute()
        {
            return QueryProcessor.Process<SenderIdentity, ISenderIdentityListQuery, SenderIdentityListQuery>(this,
                context => context.SenderIdentities());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<SenderIdentity, ISenderIdentityListQuery, SenderIdentityListQuery>(this,
                context => context.SenderIdentities());
        }

        public ISenderIdentityListQuery UseInMemoryQuery(Action<IQueryOption<SenderIdentity>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public ISenderIdentityListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}