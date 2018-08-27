using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Core
{
    public interface IDisassociateBrandedForSubUserCommand : IContextQuery<IDisassociateBrandedForSubUserCommand>

    {
        IDisassociateBrandedForSubUserCommand SubUserName(string value);
    }
}