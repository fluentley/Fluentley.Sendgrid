using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.Categories.Models;

namespace Fluentley.SendGrid.Operations.Categories.Core
{
    public interface ICategoryListQuery : IListMemoryFilterQuery<ICategoryListQuery, Category>,
        IContextQuery<ICategoryListQuery>
    {
        ICategoryListQuery UsePaging(int pageIndex, int pageSize);
        ICategoryListQuery FilterByName(string value);
    }
}