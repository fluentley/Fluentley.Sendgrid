using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.SettingMail.Models;

namespace Fluentley.SendGrid.Operations.SettingMail.Core
{
    public interface IUpdateSpamForwardingSettingCommand : IContextQuery<IUpdateSpamForwardingSettingCommand>

    {
        IUpdateSpamForwardingSettingCommand Model(SpamForwardingSetting value);
        IUpdateSpamForwardingSettingCommand EmailAddress(string value);
        IUpdateSpamForwardingSettingCommand IsEnabled(bool value);
    }
}