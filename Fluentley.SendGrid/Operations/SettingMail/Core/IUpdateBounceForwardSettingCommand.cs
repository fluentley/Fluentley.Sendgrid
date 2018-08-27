using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.SettingMail.Models;

namespace Fluentley.SendGrid.Operations.SettingMail.Core
{
    public interface IUpdateBounceForwardSettingCommand : IContextQuery<IUpdateBounceForwardSettingCommand>

    {
        IUpdateBounceForwardSettingCommand ByModel(BounceForwardSetting value);
        IUpdateBounceForwardSettingCommand EmailAddress(string value);
        IUpdateBounceForwardSettingCommand IsEnabled(bool value);
    }
}