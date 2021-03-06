﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.ReverseDnses.Core;
using Fluentley.SendGrid.Operations.ReverseDnses.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.ReverseDnses.Commands
{
    internal class DeleteReverseDnsCommand : AbstractCommand<string, DeleteReverseDnsCommand>, IDeleteReverseDnsCommand,
        ICommand<string>
    {
        public DeleteReverseDnsCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public string Id { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IDeleteReverseDnsCommand, DeleteReverseDnsCommand>(this,
                context => context.DeleteReverseDns(Id));
        }

        public Task<IResult<string>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<DeleteReverseDnsCommand>(commandJson);

            return Processor.Process<string, IDeleteReverseDnsCommand, DeleteReverseDnsCommand>(this,
                context => context.DeleteReverseDns(command.Id));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IDeleteReverseDnsCommand, DeleteReverseDnsCommand>(this,
                context => context.DeleteReverseDns(Id));
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new DeleteReverseDnsCommandValidator();
            return validator.ValidateAsync(this);
        }

        public IDeleteReverseDnsCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IDeleteReverseDnsCommand ById(string id)
        {
            Id = id;
            return this;
        }
    }
}