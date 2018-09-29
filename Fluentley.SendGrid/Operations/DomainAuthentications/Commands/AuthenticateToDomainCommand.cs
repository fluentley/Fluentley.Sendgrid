using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.DomainAuthentications.Core;
using Fluentley.SendGrid.Operations.DomainAuthentications.Models;
using Fluentley.SendGrid.Operations.DomainAuthentications.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Commands
{
    internal class AuthenticateToDomainCommand : AbstractCommand<AuthenticatedDomain, AuthenticateToDomainCommand>,
        IAuthenticateToDomainCommand,
        ICommand<AuthenticatedDomain>
    {
        public AuthenticateToDomainCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private DomainAuthenticate DomainAuthenticate { get; set; }

        public IAuthenticateToDomainCommand ByModel(DomainAuthenticate value)
        {
            if (value == null)
                return this;

            DomainAuthenticate = value;
            return this;
        }

        public IAuthenticateToDomainCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<IResult<AuthenticatedDomain>> Execute()
        {
            return Processor.Process<AuthenticatedDomain, IAuthenticateToDomainCommand, AuthenticateToDomainCommand>(
                this,context => context.AuthenticateToDomain(DomainAuthenticate));
        }

        public Task<IResult<AuthenticatedDomain>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<AuthenticateToDomainCommand>(commandJson);

            return Processor.Process<AuthenticatedDomain, IAuthenticateToDomainCommand, AuthenticateToDomainCommand>(
                this, context => context.AuthenticateToDomain(command.DomainAuthenticate));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<AuthenticatedDomain, IAuthenticateToDomainCommand, AuthenticateToDomainCommand>(
                    this,context => context.AuthenticateToDomain(DomainAuthenticate));
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new AuthenticateToDomainCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}