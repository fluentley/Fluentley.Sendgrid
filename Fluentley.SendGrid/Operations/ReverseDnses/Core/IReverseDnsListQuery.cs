using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.ReverseDnses.Models;

namespace Fluentley.SendGrid.Operations.ReverseDnses.Core
{
    public interface IReverseDnsListQuery : IListMemoryFilterQuery<IReverseDnsListQuery, ReverseDns>,
        IContextQuery<IReverseDnsListQuery>
    {
        IReverseDnsListQuery UsePaging(int pageIndex, int pageSize);

        IReverseDnsListQuery FilterByIpAddress(string ipAddress);
    }
}