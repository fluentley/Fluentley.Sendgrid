﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.ReverseDnses.Core;
using Fluentley.SendGrid.Operations.ReverseDnses.Models;

namespace Fluentley.SendGrid.Operations.ReverseDnses.Commands
{
    internal class ValidateReverseDnsCommand : AbstractCommand<ReverseDnsValidationResult, ValidateReverseDnsCommand>,
        IValidateReverseDnsCommand,
        ICommand<ReverseDnsValidationResult>
    {
        public ValidateReverseDnsCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal string Id { get; set; }

        public Task<IResult<ReverseDnsValidationResult>> Execute()
        {
            return Processor
                .Process<ReverseDnsValidationResult, IValidateReverseDnsCommand, ValidateReverseDnsCommand>(this,
                    context => context.ValidateReverseDnsById(Id));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<ReverseDnsValidationResult, IValidateReverseDnsCommand, ValidateReverseDnsCommand>(this,
                    context => context.ValidateReverseDnsById(Id));
        }

        public IValidateReverseDnsCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IValidateReverseDnsCommand ById(string id)
        {
            Id = id;
            return this;
        }
    }
}