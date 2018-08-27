using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SettingMail.Models;

namespace Fluentley.SendGrid.Operations.SettingMail.Queries
{
    public interface ISpamForwardingSettingSingleQuery : IContextQuery<ISpamForwardingSettingSingleQuery>

    {
    }

    internal class SpamForwardingSettingSingleQuery : AbstractSingleQuery<SpamForwardingSetting>,
        ISpamForwardingSettingSingleQuery,
        IQuery<SpamForwardingSetting>
    {
        public SpamForwardingSettingSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public Task<IResult<SpamForwardingSetting>> Execute()
        {
            return QueryProcessor
                .Process<SpamForwardingSetting, ISpamForwardingSettingSingleQuery, SpamForwardingSettingSingleQuery>(
                    this,
                    context => context.SpamForwardingSetting());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<SpamForwardingSetting, ISpamForwardingSettingSingleQuery, SpamForwardingSettingSingleQuery>(
                    this,
                    context => context.SpamForwardingSetting());
        }

        public ISpamForwardingSettingSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}