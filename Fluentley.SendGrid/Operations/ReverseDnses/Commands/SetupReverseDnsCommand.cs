using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.ReverseDnses.Core;
using Fluentley.SendGrid.Operations.ReverseDnses.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.ReverseDnses.Commands
{
    internal class SetupReverseDnsCommand : AbstractCommand<ReverseDns, SetupReverseDnsCommand>,
        ISetupReverseDnsCommand,
        ICommand<ReverseDns>
    {
        public SetupReverseDnsCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("domain")]
        public string DnsDomain { get; set; }

        [JsonProperty("subdomain")]
        public string DnsSubDomain { get; set; }

        [JsonProperty("ip")]
        public string DnsIpAddress { get; set; }

        public Task<IResult<ReverseDns>> Execute()
        {
            return Processor.Process<ReverseDns, ISetupReverseDnsCommand, SetupReverseDnsCommand>(this,
                context => context.SetupReverseDns(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<ReverseDns, ISetupReverseDnsCommand, SetupReverseDnsCommand>(this,
                context => context.SetupReverseDns(this));
        }

        public ISetupReverseDnsCommand IpAddress(string ipAdddress)
        {
            DnsIpAddress = ipAdddress;
            return this;
        }

        public ISetupReverseDnsCommand SubDomain(string subDomain)
        {
            DnsSubDomain = subDomain;
            return this;
        }

        public ISetupReverseDnsCommand Domain(string domain)
        {
            DnsDomain = domain;
            return this;
        }

        public ISetupReverseDnsCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}