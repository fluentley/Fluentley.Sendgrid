using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SettingInboundParse.Core;
using Fluentley.SendGrid.Operations.SettingInboundParse.Models;

namespace Fluentley.SendGrid.Operations.SettingInboundParse.Queries
{
    internal class ParseSettingSingleQuery : AbstractSingleQuery<ParseSetting>, IParseSettingSingleQuery,
        IQuery<ParseSetting>
    {
        public ParseSettingSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private string HostName { get; set; }

        public IParseSettingSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IParseSettingSingleQuery ByHostName(string value)
        {
            HostName = value;
            return this;
        }

        public Task<IResult<ParseSetting>> Execute()
        {
            return QueryProcessor.Process<ParseSetting, IParseSettingSingleQuery, ParseSettingSingleQuery>(this,
                context => context.ParseSettingByHostName(HostName));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<ParseSetting, IParseSettingSingleQuery, ParseSettingSingleQuery>(this,
                context => context.ParseSettingByHostName(HostName));
        }
    }
}