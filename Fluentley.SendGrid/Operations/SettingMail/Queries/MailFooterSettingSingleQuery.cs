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
    internal class MailFooterSettingSingleQuery : AbstractSingleQuery<MailFooterSetting>, IMailFooterSettingSingleQuery,
        IQuery<MailFooterSetting>
    {
        public MailFooterSettingSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public IMailFooterSettingSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<IResult<MailFooterSetting>> Execute()
        {
            return QueryProcessor
                .Process<MailFooterSetting, IMailFooterSettingSingleQuery, MailFooterSettingSingleQuery>(this,
                    context => context.MailFooterSetting());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<MailFooterSetting, IMailFooterSettingSingleQuery, MailFooterSettingSingleQuery>(this,
                    context => context.MailFooterSetting());
        }
    }
}