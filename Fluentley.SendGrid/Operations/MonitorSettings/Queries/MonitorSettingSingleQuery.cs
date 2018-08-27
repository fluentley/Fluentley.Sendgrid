using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.MonitorSettings.Models;

namespace Fluentley.SendGrid.Operations.MonitorSettings.Queries
{
    public interface IMonitorSettingSingleQuery : IContextQuery<IMonitorSettingSingleQuery>

    {
        IMonitorSettingSingleQuery BySubUserName(string id);
    }

    internal class MonitorSettingSingleQuery : AbstractSingleQuery<MonitorSetting>, IMonitorSettingSingleQuery,
        IQuery<MonitorSetting>
    {
        public MonitorSettingSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private string SubUserName { get; set; }

        public IMonitorSettingSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IMonitorSettingSingleQuery BySubUserName(string subUserName)
        {
            SubUserName = subUserName;
            return this;
        }

        public Task<IResult<MonitorSetting>> Execute()
        {
            return QueryProcessor.Process<MonitorSetting, IMonitorSettingSingleQuery, MonitorSettingSingleQuery>(this,
                context => context.MonitorSettingBySubUserName(SubUserName));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<MonitorSetting, IMonitorSettingSingleQuery, MonitorSettingSingleQuery>(
                this,
                context => context.MonitorSettingBySubUserName(SubUserName));
        }
    }
}