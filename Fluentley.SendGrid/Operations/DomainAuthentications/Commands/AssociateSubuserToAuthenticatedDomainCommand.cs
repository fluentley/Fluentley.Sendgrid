using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.DomainAuthentications.Core;
using Fluentley.SendGrid.Operations.DomainAuthentications.Models;
using Fluentley.SendGrid.Operations.DomainAuthentications.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Commands
{
    internal class AssociateSubuserToAuthenticatedDomainCommand :
        AbstractCommand<AuthenticatedDomain, AssociateSubuserToAuthenticatedDomainCommand>,
        IAssociateSubuserToAuthenticatedDomainCommand,
        ICommand<AuthenticatedDomain>
    {
        public AssociateSubuserToAuthenticatedDomainCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("id")]
        internal string AssociateWithDomainId { get; set; }

        [JsonProperty("username")]
        internal string SubUserName { get; set; }

        public IAssociateSubuserToAuthenticatedDomainCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IAssociateSubuserToAuthenticatedDomainCommand SubUser(string value)
        {
            SubUserName = value;
            return this;
        }

        public IAssociateSubuserToAuthenticatedDomainCommand DomainId(string id)
        {
            AssociateWithDomainId = id;
            return this;
        }

        public Task<IResult<AuthenticatedDomain>> Execute()
        {
            return Processor
                .Process<AuthenticatedDomain, IAssociateSubuserToAuthenticatedDomainCommand,
                    AssociateSubuserToAuthenticatedDomainCommand>(this,
                    context => context.AssociateSubuserToAuthenticatedDomain(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<AuthenticatedDomain, IAssociateSubuserToAuthenticatedDomainCommand,
                    AssociateSubuserToAuthenticatedDomainCommand>(this, context => context.AssociateSubuserToAuthenticatedDomain(this));
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new AssociateSubuserToAuthenticatedDomainCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}