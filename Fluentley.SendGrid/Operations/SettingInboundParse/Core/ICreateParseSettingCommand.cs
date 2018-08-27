using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.SettingInboundParse.Models;

namespace Fluentley.SendGrid.Operations.SettingInboundParse.Core
{
    public interface ICreateParseSettingCommand : IContextQuery<ICreateParseSettingCommand>

    {
        ICreateParseSettingCommand HostName(string value);
        ICreateParseSettingCommand Url(string value);
        ICreateParseSettingCommand SpamCheck(bool value);
        ICreateParseSettingCommand SendRaw(bool value);
        ICreateParseSettingCommand ByModel(ParseSetting value);
    }
}