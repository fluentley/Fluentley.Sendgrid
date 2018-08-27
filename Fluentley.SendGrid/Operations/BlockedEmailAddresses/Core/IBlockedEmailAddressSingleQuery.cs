using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.BlockedEmailAddresses.Core
{
    public interface IBlockedEmailAddressSingleQuery : IContextQuery<IBlockedEmailAddressSingleQuery>

    {
        IBlockedEmailAddressSingleQuery ByEmailAddress(string id);
    }
}