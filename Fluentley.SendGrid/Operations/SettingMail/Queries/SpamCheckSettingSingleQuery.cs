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
    internal class SpamCheckSettingSingleQuery : AbstractSingleQuery<SpamCheckSetting>, ISpamCheckSettingSingleQuery,
        IQuery<SpamCheckSetting>
    {
        public SpamCheckSettingSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public Task<IResult<SpamCheckSetting>> Execute()
        {
            return QueryProcessor.Process<SpamCheckSetting, ISpamCheckSettingSingleQuery, SpamCheckSettingSingleQuery>(
                this,
                context => context.SpamCheckSetting());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<SpamCheckSetting, ISpamCheckSettingSingleQuery, SpamCheckSettingSingleQuery>(this,
                    context => context.SpamCheckSetting());
        }

        public ISpamCheckSettingSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}