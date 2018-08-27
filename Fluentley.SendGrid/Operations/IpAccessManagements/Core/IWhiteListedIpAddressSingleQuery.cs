using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.IpAccessManagements.Core
{
    public interface IWhiteListedIpAddressSingleQuery : IContextQuery<IWhiteListedIpAddressSingleQuery>

    {
        IWhiteListedIpAddressSingleQuery ById(string id);
    }
}