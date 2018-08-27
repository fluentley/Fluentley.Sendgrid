using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Teammates.Core;

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
                context => context.DeletePendingTeammateInviteByToken(Token) /*, context =>
                {
                    var validator = new DeletePendingTeammateInviteCommandValidator(context);
                    return validator.ValidateAsync(Token);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<string, IDeletePendingTeammateInviteCommand, DeletePendingTeammateInviteCommand>(
                    this,
                    context => context.DeletePendingTeammateInviteByToken(Token) /*, context =>
                    {
                        var validator = new DeletePendingTeammateInviteCommandValidator(context);
                        return validator.ValidateAsync(Token);
                    }*/);
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
    }
}