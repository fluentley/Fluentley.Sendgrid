using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Alerts.Models;

namespace Fluentley.SendGrid.Operations.Alerts.Commands
{
    public interface IDeleteAlertCommand : IContextQuery<IDeleteAlertCommand>

    {
        IDeleteAlertCommand ById(string id);
        IDeleteAlertCommand ByModel(Alert model);
    }

    internal class DeleteAlertCommand : AbstractCommand<string, DeleteAlertCommand>, IDeleteAlertCommand,
        ICommand<string>
    {
        public DeleteAlertCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal string Id { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IDeleteAlertCommand, DeleteAlertCommand>(this,
                context => context.DeleteAlertById(Id) /*, context =>
                {
                    var validator = new DeleteAlertCommandValidator(context);
                    return validator.ValidateAsync(Id);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IDeleteAlertCommand, DeleteAlertCommand>(this,
                context => context.DeleteAlertById(Id) /*, context =>
                {
                    var validator = new DeleteAlertCommandValidator(context);
                    return validator.ValidateAsync(Id);
                }*/);
        }

        public IDeleteAlertCommand ById(string id)
        {
            Id = id;
            return this;
        }

        public IDeleteAlertCommand ByModel(Alert model)
        {
            Id = model?.Id;
            return this;
        }

        public IDeleteAlertCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}