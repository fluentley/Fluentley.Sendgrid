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
    internal class EmailAddressWhiteListSettingSingleQuery : AbstractSingleQuery<EmailAddressWhiteListSetting>,
        IEmailAddressWhiteListSettingSingleQuery,
        IQuery<EmailAddressWhiteListSetting>
    {
        public EmailAddressWhiteListSettingSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public IEmailAddressWhiteListSettingSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<IResult<EmailAddressWhiteListSetting>> Execute()
        {
            return QueryProcessor
                .Process<EmailAddressWhiteListSetting, IEmailAddressWhiteListSettingSingleQuery,
                    EmailAddressWhiteListSettingSingleQuery>(this,
                    context => context.EmailAddressWhiteListSetting());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<EmailAddressWhiteListSetting, IEmailAddressWhiteListSettingSingleQuery,
                    EmailAddressWhiteListSettingSingleQuery>(this,
                    context => context.EmailAddressWhiteListSetting());
        }
    }
}