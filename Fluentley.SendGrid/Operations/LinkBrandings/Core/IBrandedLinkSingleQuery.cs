using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Core
{
    public interface IBrandedLinkSingleQuery : IContextQuery<IBrandedLinkSingleQuery>

    {
        IBrandedLinkSingleQuery ById(string id);
    }
}