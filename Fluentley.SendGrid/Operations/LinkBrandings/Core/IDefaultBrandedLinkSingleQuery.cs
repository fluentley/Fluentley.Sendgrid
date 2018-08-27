using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Core
{
    public interface IDefaultBrandedLinkSingleQuery : IContextQuery<IDefaultBrandedLinkSingleQuery>

    {
        IDefaultBrandedLinkSingleQuery FilterByDomainUrl(string domainUrl);
    }
}