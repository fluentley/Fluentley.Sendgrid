using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.SettingMail.Models;

namespace Fluentley.SendGrid.Operations.SettingMail.Core
{
    public interface IUpdateSpamCheckSettingCommand : IContextQuery<IUpdateSpamCheckSettingCommand>

    {
        IUpdateSpamCheckSettingCommand ByModel(SpamCheckSetting value);
        IUpdateSpamCheckSettingCommand Url(string value);
        IUpdateSpamCheckSettingCommand MaxScore(int value);
        IUpdateSpamCheckSettingCommand IsEnabled(bool value);
    }
}