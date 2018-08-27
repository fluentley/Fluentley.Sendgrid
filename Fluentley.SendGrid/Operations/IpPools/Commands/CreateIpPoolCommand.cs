using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.IpPools.Core;
using Fluentley.SendGrid.Operations.IpPools.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.IpPools.Commands
{
    internal class CreateIpPoolCommand : AbstractCommand<IpPool, CreateIpPoolCommand>, ICreateIpPoolCommand,
        ICommand<IpPool>
    {
        public CreateIpPoolCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("name")]
        internal string NameOfThePool { get; set; }

        public Task<IResult<IpPool>> Execute()
        {
            return Processor.Process<IpPool, ICreateIpPoolCommand, CreateIpPoolCommand>(this,
                context => context.CreateIpPool(this) /*, context =>
                {
                    var validator = new CreateIpPoolCommandValidator();
                    return validator.ValidateAsync(this);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<IpPool, ICreateIpPoolCommand, CreateIpPoolCommand>(this,
                context => context.CreateIpPool(this) /*, context =>
                {
                    var validator = new CreateIpPoolCommandValidator();
                    return validator.ValidateAsync(this);
                }*/);
        }

        public ICreateIpPoolCommand Name(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return this;

            NameOfThePool = value;

            return this;
        }

        public ICreateIpPoolCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}