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
    internal class ResendVerificationSenderIdentityCommand :
        AbstractCommand<string, ResendVerificationSenderIdentityCommand>,
        IResendVerificationSenderIdentityCommand,
        ICommand<string>
    {
        public ResendVerificationSenderIdentityCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal string Id { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor
                .Process<string, IResendVerificationSenderIdentityCommand, ResendVerificationSenderIdentityCommand>(
                    this,
                    context => context.ResendVerificationSenderIdentityById(Id));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<string, IResendVerificationSenderIdentityCommand, ResendVerificationSenderIdentityCommand>(
                    this,
                    context => context.ResendVerificationSenderIdentityById(Id));
        }

        public IResendVerificationSenderIdentityCommand ById(string id)
        {
            Id = id;
            return this;
        }

        public IResendVerificationSenderIdentityCommand ByModel(SenderIdentity model)
        {
            Id = model?.Id;
            return this;
        }

        public IResendVerificationSenderIdentityCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
           var validator = new ResendVerificationSenderIdentityCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}