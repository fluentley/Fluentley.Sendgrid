using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.BouncedEmailAddresses.Core
{
    public interface IBouncedEmailAddressSingleQuery : IContextQuery<IBouncedEmailAddressSingleQuery>

    {
        IBouncedEmailAddressSingleQuery ByEmailAddress(string id);
    }
}