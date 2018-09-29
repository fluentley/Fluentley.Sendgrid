using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.ApiKeys.Core.Queires;
using Fluentley.SendGrid.Operations.ApiKeys.Models;
using Fluentley.SendGrid.Operations.ApiKeys.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

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
                context => context.DeleteApiKeyById(Id));
        }

        public Task<IResult<string>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<DeleteApiKeyCommand>(commandJson);

            return Processor.Process<string, IDeleteApiKeyCommand, DeleteApiKeyCommand>(this,
                context => context.DeleteApiKeyById(command.Id));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IDeleteApiKeyCommand, DeleteApiKeyCommand>(this,
                context => context.DeleteApiKeyById(Id));
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new DeleteApiKeyCommandValidator();
            return validator.ValidateAsync(this);
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
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}