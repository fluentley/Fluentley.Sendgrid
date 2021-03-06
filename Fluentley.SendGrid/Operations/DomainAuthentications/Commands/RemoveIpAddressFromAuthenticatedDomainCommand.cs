﻿using System;
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
    internal class RemoveIpAddressFromAuthenticatedDomainCommand :
        AbstractCommand<AuthenticatedDomain, RemoveIpAddressFromAuthenticatedDomainCommand>,
        IRemoveIpAddressFromAuthenticatedDomainCommand,
        ICommand<AuthenticatedDomain>
    {
        public RemoveIpAddressFromAuthenticatedDomainCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("ip")]
        internal string IpAddressToRemove { get; set; }

        internal string AuthenticatedDomainId { get; set; }

        public Task<IResult<AuthenticatedDomain>> Execute()
        {
            return Processor
                .Process<AuthenticatedDomain, IRemoveIpAddressFromAuthenticatedDomainCommand,
                    RemoveIpAddressFromAuthenticatedDomainCommand>(this,
                    context => context.RemoveIpAddressFromAuthenticatedDomain(this));
        }

        public Task<IResult<AuthenticatedDomain>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<RemoveIpAddressFromAuthenticatedDomainCommand>(commandJson);


            return Processor
                .Process<AuthenticatedDomain, IRemoveIpAddressFromAuthenticatedDomainCommand,
                    RemoveIpAddressFromAuthenticatedDomainCommand>(this,
                    context => context.RemoveIpAddressFromAuthenticatedDomain(command));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<AuthenticatedDomain, IRemoveIpAddressFromAuthenticatedDomainCommand,
                    RemoveIpAddressFromAuthenticatedDomainCommand>(this,
                    context => context.RemoveIpAddressFromAuthenticatedDomain(this));
        }

        public IRemoveIpAddressFromAuthenticatedDomainCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IRemoveIpAddressFromAuthenticatedDomainCommand IpAddress(string ipAddress)
        {
            IpAddressToRemove = ipAddress;
            return this;
        }

        public IRemoveIpAddressFromAuthenticatedDomainCommand Id(string id)
        {
            AuthenticatedDomainId = id;
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new RemoveIpAddressFromAuthenticatedDomainCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}