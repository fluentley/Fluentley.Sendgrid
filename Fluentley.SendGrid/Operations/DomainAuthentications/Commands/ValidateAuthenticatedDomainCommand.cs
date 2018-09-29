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
    internal class ValidateAuthenticatedDomainCommand :
        AbstractCommand<AuthenticatedDomainValidation, ValidateAuthenticatedDomainCommand>,
        IValidateAuthenticatedDomainCommand,
        ICommand<AuthenticatedDomainValidation>
    {
        public ValidateAuthenticatedDomainCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal string Id { get; set; }

        public Task<IResult<AuthenticatedDomainValidation>> Execute()
        {
            return Processor
                .Process<AuthenticatedDomainValidation, IValidateAuthenticatedDomainCommand,
                    ValidateAuthenticatedDomainCommand>(this,
                    context => context.ValidateAuthenticatedDomainById(Id));
        }

        public Task<IResult<AuthenticatedDomainValidation>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<ValidateAuthenticatedDomainCommand>(commandJson);

            return Processor
                .Process<AuthenticatedDomainValidation, IValidateAuthenticatedDomainCommand,
                    ValidateAuthenticatedDomainCommand>(this,
                    context => context.ValidateAuthenticatedDomainById(command.Id));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<AuthenticatedDomainValidation, IValidateAuthenticatedDomainCommand,
                    ValidateAuthenticatedDomainCommand>(this,
                    context => context.ValidateAuthenticatedDomainById(Id));
        }

        public IValidateAuthenticatedDomainCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IValidateAuthenticatedDomainCommand ById(string id)
        {
            Id = id;
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new ValidateAuthenticatedDomainCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}