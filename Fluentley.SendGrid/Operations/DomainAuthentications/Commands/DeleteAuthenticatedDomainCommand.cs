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

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Commands
{
    internal class DeleteAuthenticatedDomainCommand : AbstractCommand<string, DeleteAuthenticatedDomainCommand>,
        IDeleteAuthenticatedDomainCommand,
        ICommand<string>
    {
        public DeleteAuthenticatedDomainCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal string Id { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IDeleteAuthenticatedDomainCommand, DeleteAuthenticatedDomainCommand>(this,
                context => context.DeleteAuthenticatedDomainById(Id));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<string, IDeleteAuthenticatedDomainCommand, DeleteAuthenticatedDomainCommand>(this,
                    context => context.DeleteAuthenticatedDomainById(Id));
        }

        public IDeleteAuthenticatedDomainCommand ById(string id)
        {
            Id = id;
            return this;
        }

        public IDeleteAuthenticatedDomainCommand ByModel(AuthenticatedDomain model)
        {
            Id = model?.Id;
            return this;
        }

        public IDeleteAuthenticatedDomainCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new DeleteAuthenticatedDomainCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}