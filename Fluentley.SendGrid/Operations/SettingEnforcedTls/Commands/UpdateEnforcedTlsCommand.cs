﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SettingEnforcedTls.Core;
using Fluentley.SendGrid.Operations.SettingEnforcedTls.Models;
using Fluentley.SendGrid.Operations.SettingEnforcedTls.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.SettingEnforcedTls.Commands
{
    internal class UpdateEnforcedTlsCommand : AbstractCommand<EnforcedTls, UpdateEnforcedTlsCommand>,
        IUpdateEnforcedTlsCommand, ICommand<EnforcedTls>
    {
        public UpdateEnforcedTlsCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("require_tls")]
        public bool? RequireTls { get; set; }

        [JsonProperty("require_valid_cert")]
        public bool? RequireValidCert { get; set; }

        public Task<IResult<EnforcedTls>> Execute()
        {
            return Processor.Process<EnforcedTls, IUpdateEnforcedTlsCommand, UpdateEnforcedTlsCommand>(this,
                context => context.UpdateEnforcedTls(this));
        }

        public Task<IResult<EnforcedTls>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<UpdateEnforcedTlsCommand>(commandJson);

            return Processor.Process<EnforcedTls, IUpdateEnforcedTlsCommand, UpdateEnforcedTlsCommand>(this,
                context => context.UpdateEnforcedTls(command));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<EnforcedTls, IUpdateEnforcedTlsCommand, UpdateEnforcedTlsCommand>(this,
                context => context.UpdateEnforcedTls(this));
        }

        public IUpdateEnforcedTlsCommand ByModel(EnforcedTls value)
        {
            RequireTls = value.RequireTls;
            RequireValidCert = value.RequireValidCert;
            return this;
        }

        public IUpdateEnforcedTlsCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new UpdateEnforcedTlsCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}