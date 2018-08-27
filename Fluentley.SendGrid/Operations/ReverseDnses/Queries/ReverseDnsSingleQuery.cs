using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.ReverseDnses.Models;

namespace Fluentley.SendGrid.Operations.ReverseDnses.Queries
{
    public interface IReverseDnsSingleQuery : IContextQuery<IReverseDnsSingleQuery>

    {
        IReverseDnsSingleQuery ById(string id);
    }

    internal class ReverseDnsSingleQuery : AbstractSingleQuery<ReverseDns>, IReverseDnsSingleQuery, IQuery<ReverseDns>
    {
        public ReverseDnsSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private string Id { get; set; }

        public Task<IResult<ReverseDns>> Execute()
        {
            return QueryProcessor.Process<ReverseDns, IReverseDnsSingleQuery, ReverseDnsSingleQuery>(this,
                context => context.ReverseDnsById(Id));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<ReverseDns, IReverseDnsSingleQuery, ReverseDnsSingleQuery>(this,
                context => context.ReverseDnsById(Id));
        }

        public IReverseDnsSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IReverseDnsSingleQuery ById(string id)
        {
            Id = id;
            return this;
        }
    }
}