using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SenderIdentities.Models;

namespace Fluentley.SendGrid.Operations.SenderIdentities.Commands
{
    public interface IDeleteSenderIdentityCommand : IContextQuery<IDeleteSenderIdentityCommand>

    {
        IDeleteSenderIdentityCommand ById(string id);
        IDeleteSenderIdentityCommand ByModel(SenderIdentity model);
    }

    internal class DeleteSenderIdentityCommand : AbstractCommand<string, DeleteSenderIdentityCommand>,
        IDeleteSenderIdentityCommand, ICommand<string>
    {
        public DeleteSenderIdentityCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal string Id { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IDeleteSenderIdentityCommand, DeleteSenderIdentityCommand>(this,
                context => context.DeleteSenderIdentityById(Id) /*, context =>
                {
                    var validator = new DeleteSenderIdentityCommandValidator(context);
                    return validator.ValidateAsync(Id);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IDeleteSenderIdentityCommand, DeleteSenderIdentityCommand>(this,
                context => context.DeleteSenderIdentityById(Id) /*, context =>
                {
                    var validator = new DeleteSenderIdentityCommandValidator(context);
                    return validator.ValidateAsync(Id);
                }*/);
        }

        public IDeleteSenderIdentityCommand ById(string id)
        {
            Id = id;
            return this;
        }

        public IDeleteSenderIdentityCommand ByModel(SenderIdentity model)
        {
            Id = model?.Id;
            return this;
        }

        public IDeleteSenderIdentityCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}