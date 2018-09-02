using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SettingInboundParse.Core;
using Fluentley.SendGrid.Operations.SettingInboundParse.Models;
using Fluentley.SendGrid.Operations.SettingInboundParse.Validators;
using FluentValidation.Results;

namespace Fluentley.SendGrid.Operations.SettingInboundParse.Commands
{
    internal class DeleteParseSettingCommand : AbstractCommand<string, DeleteParseSettingCommand>,
        IDeleteParseSettingCommand, ICommand<string>
    {
        public DeleteParseSettingCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal string HostName { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IDeleteParseSettingCommand, DeleteParseSettingCommand>(this,
                context => context.DeleteParseSetting(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IDeleteParseSettingCommand, DeleteParseSettingCommand>(this,
                context => context.DeleteParseSetting(this));
        }

        public IDeleteParseSettingCommand ByModel(ParseSetting value)
        {
            HostName = value.Hostname;

            return this;
        }

        public IDeleteParseSettingCommand ByHostName(string value)
        {
            HostName = value;

            return this;
        }

        public IDeleteParseSettingCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new DeleteParseSettingCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}