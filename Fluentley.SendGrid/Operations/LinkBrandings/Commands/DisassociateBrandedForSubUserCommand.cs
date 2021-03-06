﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.LinkBrandings.Core;
using Fluentley.SendGrid.Operations.LinkBrandings.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Commands
{
    internal class DisassociateBrandedForSubUserCommand : AbstractCommand<string, DisassociateBrandedForSubUserCommand>,
        IDisassociateBrandedForSubUserCommand,
        ICommand<string>
    {
        public DisassociateBrandedForSubUserCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal string UserName { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor
                .Process<string, IDisassociateBrandedForSubUserCommand, DisassociateBrandedForSubUserCommand>(this,
                    context => context.DisassociateBrandedForSubUser(UserName));
        }

        public Task<IResult<string>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<DisassociateBrandedForSubUserCommand>(commandJson);

            return Processor
                .Process<string, IDisassociateBrandedForSubUserCommand, DisassociateBrandedForSubUserCommand>(this,
                    context => context.DisassociateBrandedForSubUser(command.UserName));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<string, IDisassociateBrandedForSubUserCommand, DisassociateBrandedForSubUserCommand>(this,
                    context => context.DisassociateBrandedForSubUser(UserName));
        }

        public IDisassociateBrandedForSubUserCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IDisassociateBrandedForSubUserCommand SubUserName(string value)
        {
            UserName = value;
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new DisassociateBrandedForSubUserCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}