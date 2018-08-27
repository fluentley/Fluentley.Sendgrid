using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.MonitorSettings.Core
{
    public interface IUpdateMonitorSettingCommand : IContextQuery<IUpdateMonitorSettingCommand>

    {
        IUpdateMonitorSettingCommand SubUserName(string subUserName);
        IUpdateMonitorSettingCommand EmailAddress(string value);
        IUpdateMonitorSettingCommand Frequency(int value);
    }
}