using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.ApiKeys.Extensions;
using Fluentley.SendGrid.Operations.ApiKeys.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.ApiKeys.Commands
{
    public interface ICreateApiKeyCommand : IContextQuery<ICreateApiKeyCommand>

    {
        ICreateApiKeyCommand ByModel(ApiKey apiKey);
        ICreateApiKeyCommand Initiate(string name, params Scope[] scopes);
        ICreateApiKeyCommand AddScope(params Scope[] scopes);
    }

    internal class CreateApiKeyCommand : AbstractCommand<ApiKey, CreateApiKeyCommand>, ICreateApiKeyCommand,
        ICommand<ApiKey>
    {
        public CreateApiKeyCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("name")]
        internal string Name { get; set; }

        [JsonProperty("scopes")]
        internal IList<string> StringScopes
        {
            get { return Scopes?.Select(x => x.DisplayName()).ToList(); }
        }

        [JsonIgnore]
        public List<Scope> Scopes { get; set; }

        public Task<IResult<ApiKey>> Execute()
        {
            return Processor.Process<ApiKey, ICreateApiKeyCommand, CreateApiKeyCommand>(this,
                context => context.CreateApiKey(this) /*, context =>
                {
                    var validator = new CreateApiKeyCommandValidator();
                    return validator.ValidateAsync(this);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<ApiKey, ICreateApiKeyCommand, CreateApiKeyCommand>(this,
                context => context.CreateApiKey(this) /*, context =>
                {
                    var validator = new CreateApiKeyCommandValidator();
                    return validator.ValidateAsync(this);
                }*/);
        }

        public ICreateApiKeyCommand ByModel(ApiKey apiKey)
        {
            if (Scopes == null)
                Scopes = new List<Scope>();

            Name = apiKey?.Name;

            if (apiKey?.Scopes?.Any() ?? false)
                Scopes.AddRange(apiKey.Scopes);
            ;
            return this;
        }

        public ICreateApiKeyCommand Initiate(string name, params Scope[] scopes)
        {
            Name = name;

            if (Scopes == null)
                Scopes = new List<Scope>();

            if (scopes.Any())
                Scopes.AddRange(scopes);

            return this;
        }

        public ICreateApiKeyCommand AddScope(params Scope[] scopes)
        {
            if (Scopes == null)
                Scopes = new List<Scope>();

            if (scopes.Any())
                Scopes.AddRange(scopes);
            return this;
        }

        public ICreateApiKeyCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}