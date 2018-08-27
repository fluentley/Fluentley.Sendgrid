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
    internal class UpdateIpPoolCommand : AbstractCommand<IpPool, UpdateIpPoolCommand>, IUpdateIpPoolCommand,
        ICommand<IpPool>
    {
        public UpdateIpPoolCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("oldName")]
        internal string OldName { get; set; }

        [JsonProperty("name")]
        internal string NewName { get; set; }

        public Task<IResult<IpPool>> Execute()
        {
            return Processor.Process<IpPool, IUpdateIpPoolCommand, UpdateIpPoolCommand>(this,
                context => context.UpdateIpPool(this) /*, context =>
                {
                    var validator = new UpdateIpPoolCommandValidator(context);
                    return validator.ValidateAsync(this);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<IpPool, IUpdateIpPoolCommand, UpdateIpPoolCommand>(this,
                context => context.UpdateIpPool(this) /*, context =>
                {
                    var validator = new UpdateIpPoolCommandValidator(context);
                    return validator.ValidateAsync(this);
                }*/);
        }

        public IUpdateIpPoolCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IUpdateIpPoolCommand ChangeName(string oldName, string newName)
        {
            OldName = oldName;
            NewName = newName;

            return this;
        }
    }
}