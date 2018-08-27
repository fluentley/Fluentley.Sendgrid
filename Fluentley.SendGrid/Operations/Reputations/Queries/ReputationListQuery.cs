using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Reputations.Core;
using Fluentley.SendGrid.Operations.Reputations.Models;

namespace Fluentley.SendGrid.Operations.Reputations.Queries
{
    internal class ReputationListQuery : AbstractListQuery<Reputation>, IReputationListQuery,
        IQuery<List<Reputation>>
    {
        public ReputationListQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal List<string> SubUserNames { get; set; }

        public Task<IResult<List<Reputation>>> Execute()
        {
            return QueryProcessor.Process<Reputation, IReputationListQuery, ReputationListQuery>(this,
                context => context.SubuserReputations(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<Reputation, IReputationListQuery, ReputationListQuery>(this,
                context => context.SubuserReputations(this));
        }

        public IReputationListQuery UseInMemoryQuery(Action<IQueryOption<Reputation>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public IReputationListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IReputationListQuery AddSubUser(params string[] values)
        {
            if (SubUserNames == null)
                SubUserNames = new List<string>();

            if (values.Any())
                SubUserNames.AddRange(values);

            return this;
        }
    }
}