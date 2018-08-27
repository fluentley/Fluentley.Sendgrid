using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.MonitorSettings.Core
{
    public interface IMonitorSettingSingleQuery : IContextQuery<IMonitorSettingSingleQuery>

    {
        IMonitorSettingSingleQuery BySubUserName(string id);
    }
}