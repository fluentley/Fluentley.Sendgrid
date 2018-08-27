using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Teammates.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Teammates.Core
{
    internal class InviteTeammateCommand : AbstractCommand<TeammateInviteResult, InviteTeammateCommand>,
        IInviteTeammateCommand,
        ICommand<TeammateInviteResult>
    {
        public InviteTeammateCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("email")]
        internal string Email { get; set; }

        [JsonProperty("scopes")]
        internal List<string> Scopes { get; set; }

        [JsonProperty("admin")]
        internal bool? IsAdmin { get; set; }

        public Task<IResult<TeammateInviteResult>> Execute()
        {
            return Processor.Process<TeammateInviteResult, IInviteTeammateCommand, InviteTeammateCommand>(this,
                context => context.InviteTeammate(this) /*, context =>
                {
                    var validator = new InviteTeammateCommandValidator(context);
                    return validator.ValidateAsync(this);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<TeammateInviteResult, IInviteTeammateCommand, InviteTeammateCommand>(this,
                context => context.InviteTeammate(this) /*, context =>
                {
                    var validator = new InviteTeammateCommandValidator(context);
                    return validator.ValidateAsync(this);
                }*/);
        }

        public IInviteTeammateCommand EmailAddress(string value)
        {
            Email = value;
            return this;
        }

        public IInviteTeammateCommand IsAdminTeammate(bool value)
        {
            IsAdmin = value;
            return this;
        }

        public IInviteTeammateCommand AddScope(params string[] values)
        {
            if (Scopes == null)
                Scopes = new List<string>();

            if (values.Any())
                Scopes.AddRange(values);

            return this;
        }

        public IInviteTeammateCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}