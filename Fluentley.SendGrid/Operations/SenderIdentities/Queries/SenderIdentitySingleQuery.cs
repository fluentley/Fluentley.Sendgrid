using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SenderIdentities.Core;
using Fluentley.SendGrid.Operations.SenderIdentities.Models;

namespace Fluentley.SendGrid.Operations.SenderIdentities.Queries
{
    internal class SenderIdentitySingleQuery : AbstractSingleQuery<SenderIdentity>, ISenderIdentitySingleQuery,
        IQuery<SenderIdentity>
    {
        public SenderIdentitySingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private string Id { get; set; }

        public Task<IResult<SenderIdentity>> Execute()
        {
            return QueryProcessor.Process<SenderIdentity, ISenderIdentitySingleQuery, SenderIdentitySingleQuery>(this,
                context => context.SenderIdentityById(Id));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<SenderIdentity, ISenderIdentitySingleQuery, SenderIdentitySingleQuery>(
                this,
                context => context.SenderIdentityById(Id));
        }

        public ISenderIdentitySingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public ISenderIdentitySingleQuery ById(string id)
        {
            Id = id;
            return this;
        }
    }
}