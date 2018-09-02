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

namespace Fluentley.SendGrid.Operations.LinkBrandings.Commands
{
    internal class ValidateBrandedLinkCommand :
        AbstractCommand<BrandedLinkValidationResult, ValidateBrandedLinkCommand>,
        IValidateBrandedLinkCommand,
        ICommand<BrandedLinkValidationResult>
    {
        public ValidateBrandedLinkCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal string Id { get; set; }

        public Task<IResult<BrandedLinkValidationResult>> Execute()
        {
            return Processor
                .Process<BrandedLinkValidationResult, IValidateBrandedLinkCommand, ValidateBrandedLinkCommand>(this,
                    context => context.ValidateBrandedLinkById(Id) /*, context =>
                    {
                        var validator = new ValidateBrandedLinkCommandValidator(context);
                        return validator.ValidateAsync(Id);
                    }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<BrandedLinkValidationResult, IValidateBrandedLinkCommand, ValidateBrandedLinkCommand>(this,
                    context => context.ValidateBrandedLinkById(Id) /*, context =>
                    {
                        var validator = new ValidateBrandedLinkCommandValidator(context);
                        return validator.ValidateAsync(Id);
                    }*/);
        }

        public IValidateBrandedLinkCommand ById(string id)
        {
            Id = id;
            return this;
        }

        public IValidateBrandedLinkCommand ByModel(BrandedLink model)
        {
            Id = model?.Id;
            return this;
        }

        public IValidateBrandedLinkCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new ValidateBrandedLinkCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}