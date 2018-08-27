using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.IpAccessManagements.Commands
{
    public interface IRemoveWhiteListedIpAddressCommand : IContextQuery<IRemoveWhiteListedIpAddressCommand>

    {
        IRemoveWhiteListedIpAddressCommand IpAddressId(params string[] ipAddressId);
    }

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
                context => context.RemoveWhiteListedIpAddress(this) /*, context =>
                {
                    var validator = new RemoveWhiteListedIpAddressCommandValidator();
                    return validator.ValidateAsync(this);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<string, IRemoveWhiteListedIpAddressCommand, RemoveWhiteListedIpAddressCommand>(
                    this,
                    context => context.RemoveWhiteListedIpAddress(this) /*, context =>
                    {
                        var validator = new RemoveWhiteListedIpAddressCommandValidator();
                        return validator.ValidateAsync(this);
                    }*/);
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
    }
}