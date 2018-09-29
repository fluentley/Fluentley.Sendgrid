using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SubUsers.Core;
using Fluentley.SendGrid.Operations.SubUsers.Models;
using Fluentley.SendGrid.Operations.SubUsers.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.SubUsers.Commands
{
    internal class UpdateSubUserCommand : AbstractCommand<SubUser, UpdateSubUserCommand>, IUpdateSubUserCommand,
        ICommand<SubUser>
    {
        private readonly string _defaultApiKey;

        public UpdateSubUserCommand(string defaultApiKey) : base(defaultApiKey)
        {
            _defaultApiKey = defaultApiKey;
        }

        internal SubUser Model { get; set; }

        public Task<IResult<SubUser>> Execute()
        {
            return Processor.Process<SubUser, IUpdateSubUserCommand, UpdateSubUserCommand>(this,
                context => context.UpdateSubUser(Model));
        }

        public Task<IResult<SubUser>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<UpdateSubUserCommand>(commandJson);


            return Processor.Process<SubUser, IUpdateSubUserCommand, UpdateSubUserCommand>(this,
                context => context.UpdateSubUser(command.Model));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<SubUser, IUpdateSubUserCommand, UpdateSubUserCommand>(this,
                context => context.UpdateSubUser(Model));
        }

        public IUpdateSubUserCommand ByModel(SubUser subUser)
        {
            Model = subUser;
            return this;
        }

        public IUpdateSubUserCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new UpdateSubUserCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}