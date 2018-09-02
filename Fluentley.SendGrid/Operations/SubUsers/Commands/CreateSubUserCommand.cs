using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SubUsers.Core;
using Fluentley.SendGrid.Operations.SubUsers.Models;
using Fluentley.SendGrid.Operations.SubUsers.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.SubUsers.Commands
{
    internal class CreateSubUserCommand : AbstractCommand<SubUser, CreateSubUserCommand>, ICreateSubUserCommand,
        ICommand<SubUser>
    {
        public CreateSubUserCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("username")]
        public string SubUserUserName { get; set; }

        [JsonProperty("email")]
        public string SubUserEmailAddress { get; set; }

        [JsonProperty("password")]
        public string SubUserPassword { get; set; }

        [JsonProperty("ips")]
        public List<string> SubUserIps { get; set; }

        public Task<IResult<SubUser>> Execute()
        {
            return Processor.Process<SubUser, ICreateSubUserCommand, CreateSubUserCommand>(this,
                context => context.CreateSubUser(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<SubUser, ICreateSubUserCommand, CreateSubUserCommand>(this,
                context => context.CreateSubUser(this));
        }

        public ICreateSubUserCommand UseContextOption(Action<IContextOption> option)
        {
           
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public ICreateSubUserCommand UserName(string value)
        {
            SubUserUserName = value;
            return this;
        }

        public ICreateSubUserCommand Password(string value)
        {
            SubUserPassword = value;
            return this;
        }

        public ICreateSubUserCommand EmailAddress(string value)
        {
            SubUserEmailAddress = value;
            return this;
        }

        public ICreateSubUserCommand AssignIp(params string[] ips)
        {
            if (SubUserIps == null)
                SubUserIps = new List<string>();

            if (ips.Any())
                SubUserIps.AddRange(ips);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new CreateSubUserCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}