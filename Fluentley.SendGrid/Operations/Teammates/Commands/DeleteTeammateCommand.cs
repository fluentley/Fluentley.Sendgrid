using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Teammates.Core;
using Fluentley.SendGrid.Operations.Teammates.Models;
using Fluentley.SendGrid.Operations.Teammates.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Teammates.Commands
{
    internal class DeleteTeammateCommand : AbstractCommand<string, DeleteTeammateCommand>, IDeleteTeammateCommand,
        ICommand<string>
    {
        public DeleteTeammateCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal string UserName { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IDeleteTeammateCommand, DeleteTeammateCommand>(this,
                context => context.DeleteTeammateByUserName(UserName));
        }

        public Task<IResult<string>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<DeleteTeammateCommand>(commandJson);

            return Processor.Process<string, IDeleteTeammateCommand, DeleteTeammateCommand>(this,
                context => context.DeleteTeammateByUserName(command.UserName));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IDeleteTeammateCommand, DeleteTeammateCommand>(this,
                context => context.DeleteTeammateByUserName(UserName));
        }

        public IDeleteTeammateCommand ByUserName(string userName)
        {
            UserName = userName;
            return this;
        }

        public IDeleteTeammateCommand ByModel(Teammate model)
        {
            UserName = model?.Username;
            return this;
        }

        public IDeleteTeammateCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new DeleteTeammateCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}