using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Core
{
    public interface IAssociateBrandedForSubUserCommand : IContextQuery<IAssociateBrandedForSubUserCommand>

    {
        IAssociateBrandedForSubUserCommand BrandedLinkId(string id);
        IAssociateBrandedForSubUserCommand SubUserName(string subUserName);
    }
}