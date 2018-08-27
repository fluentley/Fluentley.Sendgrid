using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.IpAddresses.Core;
using Fluentley.SendGrid.Operations.IpAddresses.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.IpAddresses.Commands
{
    internal class AddIpAddressCommand : AbstractCommand<AddIpResult, AddIpAddressCommand>, IAddIpAddressCommand,
        ICommand<AddIpResult>
    {
        public AddIpAddressCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("count")]
        internal int Count { get; set; }

        [JsonProperty("subusers")]
        internal List<string> SubUsers { get; set; }

        [JsonProperty("warmup")]
        internal bool? WarmUp { get; set; }

        [JsonProperty("user_can_send")]
        public bool CanUserSend { get; set; }

        public IAddIpAddressCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IAddIpAddressCommand CountOfIpAddresses(int value)
        {
            Count = value;
            return this;
        }

        public IAddIpAddressCommand AddSubUser(params string[] values)
        {
            if (SubUsers == null)
                SubUsers = new List<string>();

            if (values.Any())
                SubUsers.AddRange(values);

            return this;
        }

        public IAddIpAddressCommand IsWarmUp(bool value)
        {
            WarmUp = value;
            return this;
        }

        public IAddIpAddressCommand UserCanSend(bool value)
        {
            CanUserSend = value;
            return this;
        }

        public Task<IResult<AddIpResult>> Execute()
        {
            return Processor.Process<AddIpResult, IAddIpAddressCommand, AddIpAddressCommand>(this,
                context => context.AddIpAddress(this) /*, context =>
                {
                    var validator = new AddIpAddressCommandValidator();
                    return validator.ValidateAsync(this);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<AddIpResult, IAddIpAddressCommand, AddIpAddressCommand>(this,
                context => context.AddIpAddress(this) /*, context =>
                {
                    var validator = new AddIpAddressCommandValidator();
                    return validator.ValidateAsync(this);
                }*/);
        }
    }
}