using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SenderIdentities.Core;
using Fluentley.SendGrid.Operations.SenderIdentities.Models;
using Fluentley.SendGrid.Operations.SenderIdentities.Validators;
using FluentValidation.Results;

namespace Fluentley.SendGrid.Operations.SenderIdentities.Commands
{
    internal class DeleteSenderIdentityCommand : AbstractCommand<string, DeleteSenderIdentityCommand>,
        IDeleteSenderIdentityCommand, ICommand<string>
    {
        public DeleteSenderIdentityCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal string Id { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IDeleteSenderIdentityCommand, DeleteSenderIdentityCommand>(this,
                context => context.DeleteSenderIdentityById(Id));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IDeleteSenderIdentityCommand, DeleteSenderIdentityCommand>(this,
                context => context.DeleteSenderIdentityById(Id));
        }

        public IDeleteSenderIdentityCommand ById(string id)
        {
            Id = id;
            return this;
        }

        public IDeleteSenderIdentityCommand ByModel(SenderIdentity model)
        {
            Id = model?.Id;
            return this;
        }

        public IDeleteSenderIdentityCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        public Task<ValidationResult> Validate()
        {
            var validator = new DeleteSenderIdentityCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}