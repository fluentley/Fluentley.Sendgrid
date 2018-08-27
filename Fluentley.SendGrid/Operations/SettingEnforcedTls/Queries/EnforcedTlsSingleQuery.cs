using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SettingEnforcedTls.Core;
using Fluentley.SendGrid.Operations.SettingEnforcedTls.Models;

namespace Fluentley.SendGrid.Operations.SettingEnforcedTls.Queries
{
    internal class EnforcedTlsSingleQuery : AbstractSingleQuery<EnforcedTls>, IEnforcedTlsSingleQuery,
        IQuery<EnforcedTls>
    {
        public EnforcedTlsSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public IEnforcedTlsSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<IResult<EnforcedTls>> Execute()
        {
            return QueryProcessor.Process<EnforcedTls, IEnforcedTlsSingleQuery, EnforcedTlsSingleQuery>(this,
                context => context.EnforcedTls());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<EnforcedTls, IEnforcedTlsSingleQuery, EnforcedTlsSingleQuery>(this,
                context => context.EnforcedTls());
        }
    }
}