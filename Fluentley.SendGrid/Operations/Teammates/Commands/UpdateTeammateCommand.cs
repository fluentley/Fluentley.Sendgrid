using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Teammates.Core;
using Fluentley.SendGrid.Operations.Teammates.Models;
using Fluentley.SendGrid.Operations.Teammates.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Teammates.Commands
{
    internal class UpdateTeammateCommand : AbstractCommand<TeammateWithScope, UpdateTeammateCommand>,
        IUpdateTeammateCommand,
        ICommand<TeammateWithScope>
    {
        public UpdateTeammateCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal string UserName { get; set; }

        [JsonProperty("scopes")]
        internal List<string> Scopes { get; set; }

        [JsonProperty("admin")]
        internal bool? IsAdmin { get; set; }

        public Task<IResult<TeammateWithScope>> Execute()
        {
            return Processor.Process<TeammateWithScope, IUpdateTeammateCommand, UpdateTeammateCommand>(this,
                context => context.UpdateTeammateByUserName(this));
        }

        public Task<IResult<TeammateWithScope>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<UpdateTeammateCommand>(commandJson);

            return Processor.Process<TeammateWithScope, IUpdateTeammateCommand, UpdateTeammateCommand>(this,
                context => context.UpdateTeammateByUserName(command));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<TeammateWithScope, IUpdateTeammateCommand, UpdateTeammateCommand>(this,
                context => context.UpdateTeammateByUserName(this));
        }

        public IUpdateTeammateCommand IsAdminTeammate(bool value)
        {
            IsAdmin = value;
            return this;
        }

        public IUpdateTeammateCommand AddScope(params string[] values)
        {
            if (Scopes == null)
                Scopes = new List<string>();

            if (values.Any())
                Scopes.AddRange(values);

            return this;
        }

        public IUpdateTeammateCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new UpdateTeammateCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}