using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.IpAccessManagements.Core;
using Fluentley.SendGrid.Operations.IpAccessManagements.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.IpAccessManagements.Commands
{
    internal class RemoveWhiteListedIpAddressCommand : AbstractCommand<string, RemoveWhiteListedIpAddressCommand>,
        IRemoveWhiteListedIpAddressCommand,
        ICommand<string>
    {
        public RemoveWhiteListedIpAddressCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("ids")]
        internal List<string> Ids { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IRemoveWhiteListedIpAddressCommand, RemoveWhiteListedIpAddressCommand>(
                this,
                context => context.RemoveWhiteListedIpAddress(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<string, IRemoveWhiteListedIpAddressCommand, RemoveWhiteListedIpAddressCommand>(
                    this,
                    context => context.RemoveWhiteListedIpAddress(this));
        }

        public IRemoveWhiteListedIpAddressCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IRemoveWhiteListedIpAddressCommand IpAddressId(params string[] ipAddressId)
        {
            if (Ids == null)
                Ids = new List<string>();

            if (ipAddressId.Any())
                Ids.AddRange(ipAddressId);

            return this;
        }

        public Task<ValidationResult> Validate()
        {
           var validator = new RemoveWhiteListedIpAddressCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}