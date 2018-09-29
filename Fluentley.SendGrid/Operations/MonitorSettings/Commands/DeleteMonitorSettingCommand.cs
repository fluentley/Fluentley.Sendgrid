using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.MonitorSettings.Core;
using Fluentley.SendGrid.Operations.MonitorSettings.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.MonitorSettings.Commands
{
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
                context => context.DeleteMonitorSettingByUserName(SubUserName));
        }

        public Task<IResult<string>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<DeleteMonitorSettingCommand>(commandJson);

            return Processor.Process<string, IDeleteMonitorSettingCommand, DeleteMonitorSettingCommand>(this,
                context => context.DeleteMonitorSettingByUserName(command.SubUserName));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IDeleteMonitorSettingCommand, DeleteMonitorSettingCommand>(this,
                context => context.DeleteMonitorSettingByUserName(SubUserName));
        }

        public IDeleteMonitorSettingCommand ByUserName(string subUserName)
        {
            SubUserName = subUserName;
            return this;
        }

        public IDeleteMonitorSettingCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new DeleteMonitorSettingCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}