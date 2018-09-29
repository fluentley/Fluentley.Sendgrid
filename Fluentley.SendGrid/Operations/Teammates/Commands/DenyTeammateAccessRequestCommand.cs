using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Alerts.Models;
using Fluentley.SendGrid.Operations.Teammates.Core;
using Fluentley.SendGrid.Operations.Teammates.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Teammates.Commands
{
    internal class DenyTeammateAccessRequestCommand : AbstractCommand<string, DenyTeammateAccessRequestCommand>,
        IDenyTeammateAccessRequestCommand,
        ICommand<string>
    {
        public DenyTeammateAccessRequestCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal string Id { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IDenyTeammateAccessRequestCommand, DenyTeammateAccessRequestCommand>(this,
                context => context.DenyTeammateAccessRequestById(Id));
        }

        public Task<IResult<string>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<DenyTeammateAccessRequestCommand>(commandJson);

            return Processor.Process<string, IDenyTeammateAccessRequestCommand, DenyTeammateAccessRequestCommand>(this,
                context => context.DenyTeammateAccessRequestById(command.Id));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<string, IDenyTeammateAccessRequestCommand, DenyTeammateAccessRequestCommand>(this,
                    context => context.DenyTeammateAccessRequestById(Id));
        }

        public IDenyTeammateAccessRequestCommand ById(string id)
        {
            Id = id;
            return this;
        }

        public IDenyTeammateAccessRequestCommand ByModel(Alert model)
        {
            Id = model?.Id;
            return this;
        }

        public IDenyTeammateAccessRequestCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new DenyTeammateAccessRequestCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}