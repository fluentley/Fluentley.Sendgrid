using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.SettingMail.Models;

namespace Fluentley.SendGrid.Operations.SettingMail.Core
{
    public interface IUpdatePlainContentSettingCommand : IContextQuery<IUpdatePlainContentSettingCommand>

    {
        IUpdatePlainContentSettingCommand ByModel(PlainContentSetting value);
        IUpdatePlainContentSettingCommand IsEnabled(bool value);
    }
}