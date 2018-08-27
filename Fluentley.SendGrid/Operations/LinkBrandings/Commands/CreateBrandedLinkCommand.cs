using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.LinkBrandings.Core;
using Fluentley.SendGrid.Operations.LinkBrandings.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Commands
{
    internal class CreateBrandedLinkCommand : AbstractCommand<BrandedLink, CreateBrandedLinkCommand>,
        ICreateBrandedLinkCommand,
        ICommand<BrandedLink>
    {
        public CreateBrandedLinkCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("domain")]
        internal string DomainUrlOfBrandedLink { get; set; }

        [JsonProperty("subdomain")]
        internal string SubDomainOfBrandedLink { get; set; }

        [JsonProperty("default")]
        internal bool IsDeaultBrandedLink { get; set; }

        public Task<IResult<BrandedLink>> Execute()
        {
            return Processor.Process<BrandedLink, ICreateBrandedLinkCommand, CreateBrandedLinkCommand>(this,
                context => context.CreateBrandedLink(this) /*, context =>
                {
                    var validator = new CreateBrandedLinkCommandValidator();
                    return validator.ValidateAsync(this);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<BrandedLink, ICreateBrandedLinkCommand, CreateBrandedLinkCommand>(this,
                context => context.CreateBrandedLink(this) /*, context =>
                {
                    var validator = new CreateBrandedLinkCommandValidator();
                    return validator.ValidateAsync(this);
                }*/);
        }

        public ICreateBrandedLinkCommand DomainUrl(string value)
        {
            DomainUrlOfBrandedLink = value;
            return this;
        }

        public ICreateBrandedLinkCommand SubDomain(string value)
        {
            SubDomainOfBrandedLink = value;
            return this;
        }

        public ICreateBrandedLinkCommand IsDefault(bool value)
        {
            IsDeaultBrandedLink = value;
            return this;
        }

        public ICreateBrandedLinkCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}