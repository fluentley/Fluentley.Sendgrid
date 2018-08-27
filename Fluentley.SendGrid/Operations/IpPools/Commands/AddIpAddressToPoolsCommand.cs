﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.IpAddresses.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.IpPools.Commands
{
    public interface IAddIpAddressToPoolCommand : IContextQuery<IAddIpAddressToPoolCommand>

    {
        IAddIpAddressToPoolCommand IpAddress(string ipAddress);
        IAddIpAddressToPoolCommand PoolName(string poolName);
    }

    internal class AddIpAddressToPoolCommand : AbstractCommand<IpAddress, AddIpAddressToPoolCommand>,
        IAddIpAddressToPoolCommand,
        ICommand<IpAddress>
    {
        public AddIpAddressToPoolCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("ip")]
        internal string IpAddressToAdd { get; set; }

        [JsonProperty("ipPoolName")]
        internal string IpPoolName { get; set; }

        public IAddIpAddressToPoolCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IAddIpAddressToPoolCommand IpAddress(string ipAddress)
        {
            IpAddressToAdd = ipAddress;
            return this;
        }

        public IAddIpAddressToPoolCommand PoolName(string poolName)
        {
            IpPoolName = poolName;
            return this;
        }

        public Task<IResult<IpAddress>> Execute()
        {
            return Processor.Process<IpAddress, IAddIpAddressToPoolCommand, AddIpAddressToPoolCommand>(this,
                context => context.AddIpAddressToPool(this) /*, context =>
                {
                    var validator = new AddIpAddressToPoolCommandValidator(context);
                    return validator.ValidateAsync(this);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<IpAddress, IAddIpAddressToPoolCommand, AddIpAddressToPoolCommand>(this,
                context => context.AddIpAddressToPool(this) /*, context =>
                {
                    var validator = new AddIpAddressToPoolCommandValidator(context);
                    return validator.ValidateAsync(this);
                }*/);
        }
    }
}