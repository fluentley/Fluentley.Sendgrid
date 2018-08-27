using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.IpWarmups.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.IpWarmups.Commands
{
    public interface ICreateIpWarmupCommand : IContextQuery<ICreateIpWarmupCommand>

    {
        ICreateIpWarmupCommand IpAddress(string value);
    }

    internal class CreateIpWarmupCommand : AbstractCommand<IpWarmup, CreateIpWarmupCommand>, ICreateIpWarmupCommand,
        ICommand<IpWarmup>
    {
        public CreateIpWarmupCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("ip")]
        public string Ip { get; set; }

        public Task<IResult<IpWarmup>> Execute()
        {
            return Processor.Process<IpWarmup, ICreateIpWarmupCommand, CreateIpWarmupCommand>(this,
                context => context.CreateIpWarmup(this) /*, context =>
                {
                    var validator = new CreateIpWarmupCommandValidator();
                    return validator.ValidateAsync(this);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<IpWarmup, ICreateIpWarmupCommand, CreateIpWarmupCommand>(this,
                context => context.CreateIpWarmup(this) /*, context =>
                {
                    var validator = new CreateIpWarmupCommandValidator();
                    return validator.ValidateAsync(this);
                }*/);
        }

        public ICreateIpWarmupCommand IpAddress(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return this;

            Ip = value;
            return this;
        }

        public ICreateIpWarmupCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}