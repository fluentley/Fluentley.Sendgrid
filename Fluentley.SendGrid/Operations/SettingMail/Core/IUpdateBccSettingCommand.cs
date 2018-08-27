using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.SettingMail.Models;

namespace Fluentley.SendGrid.Operations.SettingMail.Core
{
    public interface IUpdateBccSettingCommand : IContextQuery<IUpdateBccSettingCommand>

    {
        IUpdateBccSettingCommand ByModel(BccSetting value);
        IUpdateBccSettingCommand EmailAddress(string value);
        IUpdateBccSettingCommand IsEnabled(bool value);
    }
}