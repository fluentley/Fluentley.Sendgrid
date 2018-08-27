using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.SettingMail.Models;

namespace Fluentley.SendGrid.Operations.SettingMail.Core
{
    public interface IUpdateTemplateSettingCommand : IContextQuery<IUpdateTemplateSettingCommand>

    {
        IUpdateTemplateSettingCommand ByModel(TemplateSetting value);
        IUpdateTemplateSettingCommand HtmlContent(string value);
        IUpdateTemplateSettingCommand IsEnabled(bool value);
    }
}