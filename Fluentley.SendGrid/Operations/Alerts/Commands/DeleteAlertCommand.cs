using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Alerts.Core.Commands;
using Fluentley.SendGrid.Operations.Alerts.Models;
using Fluentley.SendGrid.Operations.Alerts.Validators;
using FluentValidation.Results;

namespace Fluentley.SendGrid.Operations.Alerts.Commands
{
    internal class DeleteAlertCommand : AbstractCommand<string, DeleteAlertCommand>, IDeleteAlertCommand,
        ICommand<string>
    {
        public DeleteAlertCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal string IdForAlert { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IDeleteAlertCommand, DeleteAlertCommand>(this,
                context => context.DeleteAlertById(IdForAlert));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IDeleteAlertCommand, DeleteAlertCommand>(this,
                context => context.DeleteAlertById(IdForAlert));
        }

        public IDeleteAlertCommand ById(string id)
        {
            IdForAlert = id;
            return this;
        }

        public IDeleteAlertCommand ByModel(Alert model)
        {
            IdForAlert = model?.Id;
            return this;
        }

        public IDeleteAlertCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new DeleteAlertCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}