﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.IpWarmups.Core;
using Fluentley.SendGrid.Operations.IpWarmups.Models;
using Fluentley.SendGrid.Operations.IpWarmups.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.IpWarmups.Commands
{
    internal class CreateIpWarmupCommand : AbstractCommand<IpWarmup, CreateIpWarmupCommand>, ICreateIpWarmupCommand,
        ICommand<IpWarmup>
    {
        public CreateIpWarmupCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("ip")]
        public string Ip { get; set; }

        public Task<IResult<IpWarmup>> Execute()
        {
            return Processor.Process<IpWarmup, ICreateIpWarmupCommand, CreateIpWarmupCommand>(this,
                context => context.CreateIpWarmup(this));
        }

        public Task<IResult<IpWarmup>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<CreateIpWarmupCommand>(commandJson);

            return Processor.Process<IpWarmup, ICreateIpWarmupCommand, CreateIpWarmupCommand>(this,
                context => context.CreateIpWarmup(command));

        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<IpWarmup, ICreateIpWarmupCommand, CreateIpWarmupCommand>(this,
                context => context.CreateIpWarmup(this));
        }

        public ICreateIpWarmupCommand IpAddress(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return this;

            Ip = value;
            return this;
        }

        public ICreateIpWarmupCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new CreateIpWarmupCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}