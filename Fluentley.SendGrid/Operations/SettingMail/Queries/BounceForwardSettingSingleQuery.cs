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
    internal class BounceForwardSettingSingleQuery : AbstractSingleQuery<BounceForwardSetting>,
        IBounceForwardSettingSingleQuery,
        IQuery<BounceForwardSetting>
    {
        public BounceForwardSettingSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public IBounceForwardSettingSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<IResult<BounceForwardSetting>> Execute()
        {
            return QueryProcessor
                .Process<BounceForwardSetting, IBounceForwardSettingSingleQuery, BounceForwardSettingSingleQuery>(this,
                    context => context.BounceForwardSetting());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<BounceForwardSetting, IBounceForwardSettingSingleQuery, BounceForwardSettingSingleQuery>(this,
                    context => context.BounceForwardSetting());
        }
    }
}