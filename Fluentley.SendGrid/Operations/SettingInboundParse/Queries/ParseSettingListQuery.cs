using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SettingInboundParse.Models;

namespace Fluentley.SendGrid.Operations.SettingInboundParse.Queries
{
    public interface IParseSettingListQuery : IListMemoryFilterQuery<IParseSettingListQuery, ParseSetting>,
        IContextQuery<IParseSettingListQuery>
    {
    }

    internal class ParseSettingListQuery : AbstractListQuery<ParseSetting>, IParseSettingListQuery,
        IQuery<List<ParseSetting>>
    {
        public ParseSettingListQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public IParseSettingListQuery UseInMemoryQuery(Action<IQueryOption<ParseSetting>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public IParseSettingListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<IResult<List<ParseSetting>>> Execute()
        {
            return QueryProcessor.Process<ParseSetting, IParseSettingListQuery, ParseSettingListQuery>(this,
                context => context.ParseSettings());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<ParseSetting, IParseSettingListQuery, ParseSettingListQuery>(this,
                context => context.ParseSettings());
        }
    }
}