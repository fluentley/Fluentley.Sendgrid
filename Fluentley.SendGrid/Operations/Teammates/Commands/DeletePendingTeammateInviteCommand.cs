using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Teammates.Core;
using Fluentley.SendGrid.Operations.Teammates.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Teammates.Commands
{
    internal class DeletePendingTeammateInviteCommand : AbstractCommand<string, DeletePendingTeammateInviteCommand>,
        IDeletePendingTeammateInviteCommand,
        ICommand<string>
    {
        public DeletePendingTeammateInviteCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal string Token { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IDeletePendingTeammateInviteCommand, DeletePendingTeammateInviteCommand>(
                this,
                context => context.DeletePendingTeammateInviteByToken(Token));
        }

        public Task<IResult<string>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<DeletePendingTeammateInviteCommand>(commandJson);

            return Processor.Process<string, IDeletePendingTeammateInviteCommand, DeletePendingTeammateInviteCommand>(
                this,
                context => context.DeletePendingTeammateInviteByToken(command.Token));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<string, IDeletePendingTeammateInviteCommand, DeletePendingTeammateInviteCommand>(
                    this,
                    context => context.DeletePendingTeammateInviteByToken(Token));
        }

        public IDeletePendingTeammateInviteCommand ByToken(string value)
        {
            Token = value;
            return this;
        }

        public IDeletePendingTeammateInviteCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new DeletePendingTeammateInviteCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}