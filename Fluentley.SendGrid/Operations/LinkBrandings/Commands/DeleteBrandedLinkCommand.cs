using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.LinkBrandings.Models;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Commands
{
    public interface IDeleteBrandedLinkCommand : IContextQuery<IDeleteBrandedLinkCommand>

    {
        IDeleteBrandedLinkCommand ById(string id);
        IDeleteBrandedLinkCommand ByModel(BrandedLink model);
    }

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
                context => context.DeleteBrandedLinkById(Id) /*, context =>
                {
                    var validator = new DeleteBrandedLinkCommandValidator(context);
                    return validator.ValidateAsync(Id);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IDeleteBrandedLinkCommand, DeleteBrandedLinkCommand>(this,
                context => context.DeleteBrandedLinkById(Id) /*, context =>
                {
                    var validator = new DeleteBrandedLinkCommandValidator(context);
                    return validator.ValidateAsync(Id);
                }*/);
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
    }
}