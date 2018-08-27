using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SettingMail.Core;
using Fluentley.SendGrid.Operations.SettingMail.Models;

namespace Fluentley.SendGrid.Operations.SettingMail.Queries
{
    internal class BouncePurgeSettingSingleQuery : AbstractSingleQuery<BouncePurgeSetting>,
        IBouncePurgeSettingSingleQuery,
        IQuery<BouncePurgeSetting>
    {
        public BouncePurgeSettingSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public IBouncePurgeSettingSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<IResult<BouncePurgeSetting>> Execute()
        {
            return QueryProcessor
                .Process<BouncePurgeSetting, IBouncePurgeSettingSingleQuery, BouncePurgeSettingSingleQuery>(this,
                    context => context.BouncePurgeSetting());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<BouncePurgeSetting, IBouncePurgeSettingSingleQuery, BouncePurgeSettingSingleQuery>(this,
                    context => context.BouncePurgeSetting());
        }
    }
}