using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.SettingInboundParse.Models;

namespace Fluentley.SendGrid.Operations.SettingInboundParse.Core
{
    public interface IUpdateParseSettingCommand : IContextQuery<IUpdateParseSettingCommand>

    {
        IUpdateParseSettingCommand ByModel(ParseSetting value);
        IUpdateParseSettingCommand HostName(string value);
        IUpdateParseSettingCommand Url(string value);
        IUpdateParseSettingCommand SpamCheck(bool value);
        IUpdateParseSettingCommand SendRaw(bool value);
    }
}