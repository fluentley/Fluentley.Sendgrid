using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.DomainAuthentications.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Commands
{
    public interface
        IAssociateSubuserToAuthenticatedDomainCommand : IContextQuery<IAssociateSubuserToAuthenticatedDomainCommand>

    {
        IAssociateSubuserToAuthenticatedDomainCommand DomainId(string id);
        IAssociateSubuserToAuthenticatedDomainCommand SubUser(string value);
    }

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
                    context => context.AssociateSubuserToAuthenticatedDomain(this) /*, context =>
                    {
                        var validator = new AssociateSubuserToAuthenticatedDomainCommandValidator(context);
                        return validator.ValidateAsync(this);
                    }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<AuthenticatedDomain, IAssociateSubuserToAuthenticatedDomainCommand,
                    AssociateSubuserToAuthenticatedDomainCommand>(this,
                    context => context.AssociateSubuserToAuthenticatedDomain(this) /*, context =>
                    {
                        var validator = new AssociateSubuserToAuthenticatedDomainCommandValidator(context);
                        return validator.ValidateAsync(this);
                    }*/);
        }
    }
}