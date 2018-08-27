using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SettingMail.Models;

namespace Fluentley.SendGrid.Operations.SettingMail.Queries
{
    public interface IPlainContentSettingSingleQuery : IContextQuery<IPlainContentSettingSingleQuery>

    {
    }

    internal class PlainContentSettingSingleQuery : AbstractSingleQuery<PlainContentSetting>,
        IPlainContentSettingSingleQuery,
        IQuery<PlainContentSetting>
    {
        public PlainContentSettingSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public IPlainContentSettingSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<IResult<PlainContentSetting>> Execute()
        {
            return QueryProcessor
                .Process<PlainContentSetting, IPlainContentSettingSingleQuery, PlainContentSettingSingleQuery>(this,
                    context => context.PlainContentSetting());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<PlainContentSetting, IPlainContentSettingSingleQuery, PlainContentSettingSingleQuery>(this,
                    context => context.PlainContentSetting());
        }
    }
}