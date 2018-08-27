using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.SettingMail.Models;

namespace Fluentley.SendGrid.Operations.SettingMail.Core
{
    public interface
        IUpdateEmailAddressWhiteListSettingCommand : IContextQuery<IUpdateEmailAddressWhiteListSettingCommand>

    {
        IUpdateEmailAddressWhiteListSettingCommand ByModel(EmailAddressWhiteListSetting value);
        IUpdateEmailAddressWhiteListSettingCommand AddEmailAddress(string value);
        IUpdateEmailAddressWhiteListSettingCommand IsEnabled(bool value);
    }
}