using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.IpAddresses.Models;

namespace Fluentley.SendGrid.Operations.IpAddresses.Queries
{
    public interface IIpAddressListQuery : IListMemoryFilterQuery<IIpAddressListQuery, IpAddress>,
        IContextQuery<IIpAddressListQuery>
    {
        IIpAddressListQuery UsePaging(int pageIndex, int pageSize);
        IIpAddressListQuery FilterBySubuser(string value);
        IIpAddressListQuery ShouldExcludeWhiteLabels(bool value);
        IIpAddressListQuery SortBy(SortDirection value);
        IIpAddressListQuery FilterByIpAddress(string value);
    }

    internal class IpAddressListQuery : AbstractListQuery<IpAddress>, IIpAddressListQuery, IQuery<List<IpAddress>>
    {
        public IpAddressListQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal int? PageSize { get; set; }

        internal int? PageIndex { get; set; }
        internal string SubUser { get; set; }
        internal string IpAddress { get; set; }
        internal bool? ExcludeWhiteLables { get; set; }
        internal SortDirection Direction { get; set; }

        public IIpAddressListQuery UseInMemoryQuery(Action<IQueryOption<IpAddress>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public IIpAddressListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IIpAddressListQuery UsePaging(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            return this;
        }

        public IIpAddressListQuery FilterBySubuser(string value)
        {
            SubUser = value;
            return this;
        }

        public IIpAddressListQuery ShouldExcludeWhiteLabels(bool value)
        {
            ExcludeWhiteLables = value;
            return this;
        }

        public IIpAddressListQuery SortBy(SortDirection value)
        {
            Direction = value;
            return this;
        }

        public IIpAddressListQuery FilterByIpAddress(string value)
        {
            IpAddress = value;
            return this;
        }

        public Task<IResult<List<IpAddress>>> Execute()
        {
            return QueryProcessor.Process<IpAddress, IIpAddressListQuery, IpAddressListQuery>(this,
                context => context.IpAddresses(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<IpAddress, IIpAddressListQuery, IpAddressListQuery>(this,
                context => context.IpAddresses(this));
        }
    }
}