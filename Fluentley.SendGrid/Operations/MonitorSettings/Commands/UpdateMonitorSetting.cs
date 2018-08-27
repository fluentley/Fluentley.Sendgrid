using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.MonitorSettings.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.MonitorSettings.Commands
{
    public interface IUpdateMonitorSettingCommand : IContextQuery<IUpdateMonitorSettingCommand>

    {
        IUpdateMonitorSettingCommand SubUserName(string subUserName);
        IUpdateMonitorSettingCommand EmailAddress(string value);
        IUpdateMonitorSettingCommand Frequency(int value);
    }

    internal class UpdateMonitorSettingCommand : AbstractCommand<MonitorSetting, UpdateMonitorSettingCommand>,
        IUpdateMonitorSettingCommand,
        ICommand<MonitorSetting>
    {
        private readonly string _defaultApiKey;

        public UpdateMonitorSettingCommand(string defaultApiKey) : base(defaultApiKey)
        {
            _defaultApiKey = defaultApiKey;
        }

        [JsonProperty("userName")]
        internal string UserName { get; set; }

        [JsonProperty("email")]
        internal string Email { get; set; }

        [JsonProperty("frequency")]

        internal int FrequencyValue { get; set; }

        public Task<IResult<MonitorSetting>> Execute()
        {
            return Processor.Process<MonitorSetting, IUpdateMonitorSettingCommand, UpdateMonitorSettingCommand>(this,
                context => context.UpdateMonitorSettingByUserName(UserName, this) /*, context =>
                {
                    var validator = new UpdateMonitorSettingCommandValidator(_defaultApiKey, context);
                    return validator.ValidateAsync(options => options
                        .FilterBySubUserName(SubUserName)
                        .UsePaging(0, 1));
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<MonitorSetting, IUpdateMonitorSettingCommand, UpdateMonitorSettingCommand>(
                this,
                context => context.UpdateMonitorSettingByUserName(UserName, this) /*, context =>
                {
                    var validator = new UpdateMonitorSettingCommandValidator(_defaultApiKey, context);
                    return validator.ValidateAsync(options => options
                        .FilterBySubUserName(SubUserName)
                        .UsePaging(0, 1));
                }*/);
        }

        public IUpdateMonitorSettingCommand SubUserName(string subUserName)
        {
            UserName = subUserName;
            return this;
        }

        public IUpdateMonitorSettingCommand EmailAddress(string value)
        {
            Email = value;
            return this;
        }

        public IUpdateMonitorSettingCommand Frequency(int value)
        {
            FrequencyValue = value;
            return this;
        }

        public IUpdateMonitorSettingCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}