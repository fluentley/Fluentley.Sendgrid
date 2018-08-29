using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Alerts.Core;
using Fluentley.SendGrid.Operations.Alerts.Models;
using Fluentley.SendGrid.Operations.Alerts.Validators;

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
                context => context.DeleteAlertById(IdForAlert), context =>
                {
                    var validator = new DeleteAlertCommandValidator();
                    return validator.ValidateAsync(this);
                });
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IDeleteAlertCommand, DeleteAlertCommand>(this,
                context => context.DeleteAlertById(IdForAlert), context =>
                {
                    var validator = new DeleteAlertCommandValidator();
                    return validator.ValidateAsync(this);
                });
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
    }
}