using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.IpWarmups.Models;

namespace Fluentley.SendGrid.Operations.IpWarmups.Queries
{
    public interface IIpWarmupSingleQuery : IContextQuery<IIpWarmupSingleQuery>

    {
        IIpWarmupSingleQuery ByIpAddress(string ipAddress);
    }

    internal class IpWarmupSingleQuery : AbstractSingleQuery<IpWarmup>, IIpWarmupSingleQuery, IQuery<IpWarmup>
    {
        public IpWarmupSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private string IpAddress { get; set; }

        public IIpWarmupSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IIpWarmupSingleQuery ByIpAddress(string ipAddress)
        {
            IpAddress = ipAddress;
            return this;
        }

        public Task<IResult<IpWarmup>> Execute()
        {
            return QueryProcessor.Process<IpWarmup, IIpWarmupSingleQuery, IpWarmupSingleQuery>(this,
                context => context.IpWarmupByIpAddress(IpAddress));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<IpWarmup, IIpWarmupSingleQuery, IpWarmupSingleQuery>(this,
                context => context.IpWarmupByIpAddress(IpAddress));
        }
    }
}