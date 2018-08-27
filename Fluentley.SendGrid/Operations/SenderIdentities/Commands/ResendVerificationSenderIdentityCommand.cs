using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SenderIdentities.Models;

namespace Fluentley.SendGrid.Operations.SenderIdentities.Commands
{
    public interface IResendVerificationSenderIdentityCommand : IContextQuery<IResendVerificationSenderIdentityCommand>

    {
        IResendVerificationSenderIdentityCommand ById(string id);
        IResendVerificationSenderIdentityCommand ByModel(SenderIdentity model);
    }

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
                    context => context.ResendVerificationSenderIdentityById(Id) /*, context =>
                    {
                        var validator = new ResendVerificationSenderIdentityCommandValidator(context);
                        return validator.ValidateAsync(Id);
                    }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<string, IResendVerificationSenderIdentityCommand, ResendVerificationSenderIdentityCommand>(
                    this,
                    context => context.ResendVerificationSenderIdentityById(Id) /*, context =>
                    {
                        var validator = new ResendVerificationSenderIdentityCommandValidator(context);
                        return validator.ValidateAsync(Id);
                    }*/);
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
    }
}