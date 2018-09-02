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
    internal class AddIpAddressToAuthenticatedDomainCommand :
        AbstractCommand<AuthenticatedDomain, AddIpAddressToAuthenticatedDomainCommand>,
        IAddIpAddressToAuthenticatedDomainCommand,
        ICommand<AuthenticatedDomain>
    {
        public AddIpAddressToAuthenticatedDomainCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("ip")]
        internal string IpAddressToAdd { get; set; }

        [JsonProperty("id")]
        internal string AuthenticatedDomainId { get; set; }

        public IAddIpAddressToAuthenticatedDomainCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IAddIpAddressToAuthenticatedDomainCommand IpAddress(string ipAddress)
        {
            IpAddressToAdd = ipAddress;
            return this;
        }

        public IAddIpAddressToAuthenticatedDomainCommand Id(string id)
        {
            AuthenticatedDomainId = id;
            return this;
        }

        public Task<IResult<AuthenticatedDomain>> Execute()
        {
            return Processor
                .Process<AuthenticatedDomain, IAddIpAddressToAuthenticatedDomainCommand,
                    AddIpAddressToAuthenticatedDomainCommand>(this,
                    context => context.AddIpAddressToAuthenticatedDomain(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<AuthenticatedDomain, IAddIpAddressToAuthenticatedDomainCommand,
                    AddIpAddressToAuthenticatedDomainCommand>(this,
                    context => context.AddIpAddressToAuthenticatedDomain(this));
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new AddIpAddressToAuthenticatedDomainCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}