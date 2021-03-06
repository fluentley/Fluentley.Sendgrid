﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.IpPools.Core;
using Fluentley.SendGrid.Operations.IpPools.Models;
using Fluentley.SendGrid.Operations.IpPools.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.IpPools.Commands
{
    internal class DeleteIpPoolCommand : AbstractCommand<string, DeleteIpPoolCommand>, IDeleteIpPoolCommand,
        ICommand<string>
    {
        public DeleteIpPoolCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal string Name { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IDeleteIpPoolCommand, DeleteIpPoolCommand>(this,
                context => context.DeleteIpPoolByName(Name));
        }

        public Task<IResult<string>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<DeleteIpPoolCommand>(commandJson);

            return Processor.Process<string, IDeleteIpPoolCommand, DeleteIpPoolCommand>(this,
                context => context.DeleteIpPoolByName(command.Name));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IDeleteIpPoolCommand, DeleteIpPoolCommand>(this,
                context => context.DeleteIpPoolByName(Name));
        }

        public IDeleteIpPoolCommand ByName(string name)
        {
            Name = name;
            return this;
        }

        public IDeleteIpPoolCommand ByModel(IpPool model)
        {
            Name = model?.Name;
            return this;
        }

        public IDeleteIpPoolCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new DeleteIpPoolCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}