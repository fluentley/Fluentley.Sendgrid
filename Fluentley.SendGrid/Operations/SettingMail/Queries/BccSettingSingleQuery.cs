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
    internal class BccSettingSingleQuery : AbstractSingleQuery<BccSetting>, IBccSettingSingleQuery,
        IQuery<BccSetting>
    {
        public BccSettingSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public IBccSettingSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<IResult<BccSetting>> Execute()
        {
            return QueryProcessor.Process<BccSetting, IBccSettingSingleQuery, BccSettingSingleQuery>(this,
                context => context.BccSetting());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<BccSetting, IBccSettingSingleQuery, BccSettingSingleQuery>(this,
                context => context.BccSetting());
        }
    }
}