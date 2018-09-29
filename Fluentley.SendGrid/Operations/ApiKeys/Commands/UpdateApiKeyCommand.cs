using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.ApiKeys.Core.Queires;
using Fluentley.SendGrid.Operations.ApiKeys.Extensions;
using Fluentley.SendGrid.Operations.ApiKeys.Models;
using Fluentley.SendGrid.Operations.ApiKeys.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.ApiKeys.Commands
{
    internal class UpdateApiKeyCommand : AbstractCommand<ApiKey, UpdateApiKeyCommand>, IUpdateApiKeyCommand,
        ICommand<ApiKey>
    {
        private readonly SendGridService _service;

        public UpdateApiKeyCommand(string defaultApiKey) : base(defaultApiKey)
        {
            _service = new SendGridService(defaultApiKey);
        }

        [JsonProperty("id")]
        internal string ApiKeyId { get; set; }

        [JsonProperty("name")]
        public string ApiKeyName { get; set; }

        [JsonProperty("scopes")]
        internal IList<string> StringScopes => Scopes?.Select(x => x.DisplayName())?.ToList();

        [JsonIgnore]
        public List<Scope> Scopes { get; set; }

        public Task<IResult<ApiKey>> Execute()
        {
            return Processor.Process<ApiKey, IUpdateApiKeyCommand, UpdateApiKeyCommand>(this,
                context => context.UpdateApiKey(this));
        }

        public Task<IResult<ApiKey>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<UpdateApiKeyCommand>(commandJson);

            return Processor.Process<ApiKey, IUpdateApiKeyCommand, UpdateApiKeyCommand>(this,
                context => context.UpdateApiKey(command));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<ApiKey, IUpdateApiKeyCommand, UpdateApiKeyCommand>(this,
                context => context.UpdateApiKey(this));
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new UpdateApiKeyCommandValidator();
            return validator.ValidateAsync(this);
        }

        public IUpdateApiKeyCommand ByModel(ApiKey apiKey)
        {
            ApiKeyId = apiKey?.Id;
            ApiKeyName = apiKey?.Name;

            if (apiKey?.Scopes?.Any() ?? false)
                Scopes.AddRange(apiKey.Scopes);

            return this;
        }

        public IUpdateApiKeyCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IUpdateApiKeyCommand Id(string id)
        {
            ApiKeyId = id;
            return this;
        }

        public IUpdateApiKeyCommand Name(string value)
        {
            ApiKeyName = value;
            return this;
        }

        public IUpdateApiKeyCommand ResetScopes()
        {
            Scopes = new List<Scope>();
            return this;
        }

        public IUpdateApiKeyCommand AddToExistingScopes(params Scope[] scopes)
        {
            if (scopes.Any())
                Scopes?.AddRange(scopes);

            return this;
        }
    }
}