using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.InvalidEmailAddresses.Core
{
    public interface IInvalidEmailAddressSingleQuery : IContextQuery<IInvalidEmailAddressSingleQuery>

    {
        IInvalidEmailAddressSingleQuery ByEmailAddress(string id);
    }
}