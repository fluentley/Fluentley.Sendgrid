using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.IpWarmups.Models;

namespace Fluentley.SendGrid.Operations.IpWarmups.Commands
{
    public interface IDeleteIpWarmupCommand : IContextQuery<IDeleteIpWarmupCommand>

    {
        IDeleteIpWarmupCommand ByIpAddress(string ipAddress);
        IDeleteIpWarmupCommand ByModel(IpWarmup model);
    }

    internal class DeleteIpWarmupCommand : AbstractCommand<string, DeleteIpWarmupCommand>, IDeleteIpWarmupCommand,
        ICommand<string>
    {
        public DeleteIpWarmupCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal string IpAddress { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IDeleteIpWarmupCommand, DeleteIpWarmupCommand>(this,
                context => context.DeleteIpWarmupById(IpAddress) /*, context =>
                {
                    var validator = new DeleteIpWarmupCommandValidator(context);
                    return validator.ValidateAsync(IpAddress);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IDeleteIpWarmupCommand, DeleteIpWarmupCommand>(this,
                context => context.DeleteIpWarmupById(IpAddress) /*, context =>
                {
                    var validator = new DeleteIpWarmupCommandValidator(context);
                    return validator.ValidateAsync(IpAddress);
                }*/);
        }

        public IDeleteIpWarmupCommand ByIpAddress(string ipAddress)
        {
            IpAddress = ipAddress;
            return this;
        }

        public IDeleteIpWarmupCommand ByModel(IpWarmup model)
        {
            IpAddress = model?.Ip;
            return this;
        }

        public IDeleteIpWarmupCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}