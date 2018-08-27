using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.IpAccessManagements.Models;

namespace Fluentley.SendGrid.Operations.IpAccessManagements.Core
{
    public interface IIpAccessManagementSettingActivityListQuery : IListMemoryFilterQuery<
            IIpAccessManagementSettingActivityListQuery, IpAccessManagementSettingActivity>,
        IContextQuery<IIpAccessManagementSettingActivityListQuery>
    {
        IIpAccessManagementSettingActivityListQuery LimitResults(int value);
    }
}