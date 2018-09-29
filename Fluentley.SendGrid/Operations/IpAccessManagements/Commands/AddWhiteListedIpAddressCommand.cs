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
using Fluentley.SendGrid.Operations.IpAccessManagements.Models;
using Fluentley.SendGrid.Operations.IpAccessManagements.Validators;
using Fluentley.SendGrid.Operations.IpAddresses.Models;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.IpAccessManagements.Commands
{
    internal class AddWhiteListedIpAddressCommand :
        AbstractCommand<List<WhiteListedIpAddress>, AddWhiteListedIpAddressCommand>,
        IAddWhiteListedIpAddressCommand,
        ICommand<List<WhiteListedIpAddress>>
    {
        public AddWhiteListedIpAddressCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("ips")]
        internal List<IpBase> IpAddresses { get; set; }

        public IAddWhiteListedIpAddressCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IAddWhiteListedIpAddressCommand Add(params string[] values)
        {
            if (IpAddresses == null)
                IpAddresses = new List<IpBase>();

            if (values.Any())
                IpAddresses.AddRange(values.Select(x => new IpBase
                {
                    IpAddress = x
                }));

            return this;
        }

        public Task<IResult<List<WhiteListedIpAddress>>> Execute()
        {
            return Processor
                .Process<List<WhiteListedIpAddress>, IAddWhiteListedIpAddressCommand, AddWhiteListedIpAddressCommand>(
                    this,
                    context => context.AddWhiteListedIpAddress(this));
        }

        public Task<IResult<List<WhiteListedIpAddress>>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<AddWhiteListedIpAddressCommand>(commandJson);

            return Processor
                .Process<List<WhiteListedIpAddress>, IAddWhiteListedIpAddressCommand, AddWhiteListedIpAddressCommand>(
                    this,
                    context => context.AddWhiteListedIpAddress(command));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<List<WhiteListedIpAddress>, IAddWhiteListedIpAddressCommand, AddWhiteListedIpAddressCommand>(
                    this,
                    context => context.AddWhiteListedIpAddress(this));
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new AddWhiteListedIpAddressCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}