using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.IpAccessManagements.Models;

namespace Fluentley.SendGrid.Operations.IpAccessManagements.Queries
{
    public interface IWhiteListedIpAddressSingleQuery : IContextQuery<IWhiteListedIpAddressSingleQuery>

    {
        IWhiteListedIpAddressSingleQuery ById(string id);
    }

    internal class WhiteListedIpAddressSingleQuery : AbstractSingleQuery<WhiteListedIpAddress>,
        IWhiteListedIpAddressSingleQuery,
        IQuery<WhiteListedIpAddress>
    {
        public WhiteListedIpAddressSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private string Id { get; set; }

        public Task<IResult<WhiteListedIpAddress>> Execute()
        {
            return QueryProcessor
                .Process<WhiteListedIpAddress, IWhiteListedIpAddressSingleQuery, WhiteListedIpAddressSingleQuery>(this,
                    context => context.WhiteListedIpAddressById(Id));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<WhiteListedIpAddress, IWhiteListedIpAddressSingleQuery, WhiteListedIpAddressSingleQuery>(this,
                    context => context.WhiteListedIpAddressById(Id));
        }

        public IWhiteListedIpAddressSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IWhiteListedIpAddressSingleQuery ById(string id)
        {
            Id = id;
            return this;
        }
    }
}