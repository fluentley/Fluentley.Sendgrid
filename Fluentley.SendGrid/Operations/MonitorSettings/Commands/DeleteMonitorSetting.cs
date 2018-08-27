using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;

namespace Fluentley.SendGrid.Operations.MonitorSettings.Commands
{
    public interface IDeleteMonitorSettingCommand : IContextQuery<IDeleteMonitorSettingCommand>

    {
        IDeleteMonitorSettingCommand ByUserName(string id);
    }

    internal class DeleteMonitorSettingCommand : AbstractCommand<string, DeleteMonitorSettingCommand>,
        IDeleteMonitorSettingCommand, ICommand<string>
    {
        private readonly string _defaultApiKey;

        public DeleteMonitorSettingCommand(string defaultApiKey) : base(defaultApiKey)
        {
            _defaultApiKey = defaultApiKey;
        }

        public string SubUserName { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IDeleteMonitorSettingCommand, DeleteMonitorSettingCommand>(this,
                context => context.DeleteMonitorSettingByUserName(SubUserName) /*, context =>
                {
                    var validator = new DeleteMonitorSettingCommandValidator(_defaultApiKey, context);
                    return validator.ValidateAsync(options => options
                        .FilterBySubUserName(SubUserName)
                        .UsePaging(0, 1));
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IDeleteMonitorSettingCommand, DeleteMonitorSettingCommand>(this,
                context => context.DeleteMonitorSettingByUserName(SubUserName) /*, context =>
                {
                    var validator = new DeleteMonitorSettingCommandValidator(_defaultApiKey, context);
                    return validator.ValidateAsync(options => options
                        .FilterBySubUserName(SubUserName)
                        .UsePaging(0, 1));
                }*/);
        }

        public IDeleteMonitorSettingCommand ByUserName(string subUserName)
        {
            SubUserName = subUserName;
            return this;
        }

        public IDeleteMonitorSettingCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}