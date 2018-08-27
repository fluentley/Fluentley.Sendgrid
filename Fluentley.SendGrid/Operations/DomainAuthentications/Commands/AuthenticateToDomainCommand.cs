using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.DomainAuthentications.Core;
using Fluentley.SendGrid.Operations.DomainAuthentications.Models;

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
                this,
                context => context.AuthenticateToDomain(DomainAuthenticate) /*, context =>
                {
                    var validator = new AuthenticateToDomainCommandValidator(context);
                    return validator.ValidateAsync(this);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<AuthenticatedDomain, IAuthenticateToDomainCommand, AuthenticateToDomainCommand>(
                    this,
                    context => context.AuthenticateToDomain(DomainAuthenticate) /*, context =>
                    {
                        var validator = new AuthenticateToDomainCommandValidator(context);
                        return validator.ValidateAsync(this);
                    }*/);
        }
    }
}