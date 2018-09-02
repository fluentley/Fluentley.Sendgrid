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
    internal class DeleteBrandedLinkCommand : AbstractCommand<string, DeleteBrandedLinkCommand>,
        IDeleteBrandedLinkCommand, ICommand<string>
    {
        public DeleteBrandedLinkCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal string Id { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IDeleteBrandedLinkCommand, DeleteBrandedLinkCommand>(this,
                context => context.DeleteBrandedLinkById(Id));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IDeleteBrandedLinkCommand, DeleteBrandedLinkCommand>(this,
                context => context.DeleteBrandedLinkById(Id));
        }

        public IDeleteBrandedLinkCommand ById(string id)
        {
            Id = id;
            return this;
        }

        public IDeleteBrandedLinkCommand ByModel(BrandedLink model)
        {
            Id = model?.Id;
            return this;
        }

        public IDeleteBrandedLinkCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new DeleteBrandedLinkCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}