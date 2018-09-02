using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.IpPools.Core;
using Fluentley.SendGrid.Operations.IpPools.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.IpPools.Commands
{
    internal class RemoveIpAddressFromPoolCommand : AbstractCommand<string, RemoveIpAddressFromPoolCommand>,
        IRemoveIpAddressFromPoolCommand,
        ICommand<string>
    {
        public RemoveIpAddressFromPoolCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("ip")]
        internal string IpAddressToRemove { get; set; }

        internal string IpPoolName { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IRemoveIpAddressFromPoolCommand, RemoveIpAddressFromPoolCommand>(this,
                context => context.RemoveIpAddressFromPool(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IRemoveIpAddressFromPoolCommand, RemoveIpAddressFromPoolCommand>(
                this,
                context => context.RemoveIpAddressFromPool(this));
        }

        public IRemoveIpAddressFromPoolCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IRemoveIpAddressFromPoolCommand IpAddress(string ipAddress)
        {
            IpAddressToRemove = ipAddress;
            return this;
        }

        public IRemoveIpAddressFromPoolCommand PoolName(string poolName)
        {
            IpPoolName = poolName;
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new RemoveIpAddressFromPoolCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}