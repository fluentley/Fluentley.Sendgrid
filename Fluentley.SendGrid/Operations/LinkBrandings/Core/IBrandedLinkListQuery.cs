using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.LinkBrandings.Models;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Core
{
    public interface IBrandedLinkListQuery : IListMemoryFilterQuery<IBrandedLinkListQuery, BrandedLink>,
        IContextQuery<IBrandedLinkListQuery>
    {
        IBrandedLinkListQuery LimitResults(int value);
    }
}