using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Core
{
    public interface IBrandedLinkForSubuserSingleQuery : IContextQuery<IBrandedLinkForSubuserSingleQuery>

    {
        IBrandedLinkForSubuserSingleQuery BySubUserName(string subUserName);
    }
}