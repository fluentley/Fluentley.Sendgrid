using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.LinkBrandings.Core;
using Fluentley.SendGrid.Operations.LinkBrandings.Models;
using Fluentley.SendGrid.Operations.LinkBrandings.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Commands
{
    internal class UpdateBrandedLinkCommand : AbstractCommand<BrandedLink, UpdateBrandedLinkCommand>,
        IUpdateBrandedLinkCommand,
        ICommand<BrandedLink>
    {
        public UpdateBrandedLinkCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("id")]
        internal string Id { get; set; }

        [JsonProperty("default")]
        internal bool? IsDefaultForBrandedLink { get; set; }

        public Task<IResult<BrandedLink>> Execute()
        {
            return Processor.Process<BrandedLink, IUpdateBrandedLinkCommand, UpdateBrandedLinkCommand>(this,
                context => context.UpdateBrandedLink(this));
        }

        public Task<IResult<BrandedLink>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<UpdateBrandedLinkCommand>(commandJson);

            return Processor.Process<BrandedLink, IUpdateBrandedLinkCommand, UpdateBrandedLinkCommand>(this,
                context => context.UpdateBrandedLink(command));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<BrandedLink, IUpdateBrandedLinkCommand, UpdateBrandedLinkCommand>(this,
                context => context.UpdateBrandedLink(this));
        }

        public IUpdateBrandedLinkCommand IsDefault(bool value)
        {
            IsDefaultForBrandedLink = value;
            return this;
        }

        public IUpdateBrandedLinkCommand ById(string value)
        {
            Id = value;
            return this;
        }

        public IUpdateBrandedLinkCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new UpdateBrandedLinkCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}