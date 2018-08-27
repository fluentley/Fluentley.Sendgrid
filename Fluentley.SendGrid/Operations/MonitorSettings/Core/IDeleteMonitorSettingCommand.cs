using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.MonitorSettings.Core
{
    public interface IDeleteMonitorSettingCommand : IContextQuery<IDeleteMonitorSettingCommand>

    {
        IDeleteMonitorSettingCommand ByUserName(string id);
    }
}