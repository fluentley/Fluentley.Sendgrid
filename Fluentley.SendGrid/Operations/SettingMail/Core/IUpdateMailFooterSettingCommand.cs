using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.SettingMail.Models;

namespace Fluentley.SendGrid.Operations.SettingMail.Core
{
    public interface IUpdateMailFooterSettingCommand : IContextQuery<IUpdateMailFooterSettingCommand>

    {
        IUpdateMailFooterSettingCommand ByModel(MailFooterSetting value);
        IUpdateMailFooterSettingCommand HtmlContent(string value);
        IUpdateMailFooterSettingCommand PlainContent(string value);
        IUpdateMailFooterSettingCommand IsEnabled(bool value);
    }
}