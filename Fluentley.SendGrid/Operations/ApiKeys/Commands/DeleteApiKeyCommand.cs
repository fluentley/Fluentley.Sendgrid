using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.ApiKeys.Core;
using Fluentley.SendGrid.Operations.ApiKeys.Models;

namespace Fluentley.SendGrid.Operations.ApiKeys.Commands
{
    internal class DeleteApiKeyCommand : AbstractCommand<string, DeleteApiKeyCommand>, IDeleteApiKeyCommand,
        ICommand<string>
    {
        public DeleteApiKeyCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public string Id { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IDeleteApiKeyCommand, DeleteApiKeyCommand>(this,
                context => context.DeleteApiKeyById(Id) /*, context =>
                {
                    var validator = new DeleteApiKeyCommandValidator(context);
                    return validator.ValidateAsync(Id);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IDeleteApiKeyCommand, DeleteApiKeyCommand>(this,
                context => context.DeleteApiKeyById(Id) /*, context =>
                {
                    var validator = new DeleteApiKeyCommandValidator(context);
                    return validator.ValidateAsync(Id);
                }*/);
        }

        public IDeleteApiKeyCommand ById(string id)
        {
            Id = id;
            return this;
        }

        public IDeleteApiKeyCommand ByModel(ApiKey value)
        {
            Id = value?.Id;
            return this;
        }

        public IDeleteApiKeyCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}