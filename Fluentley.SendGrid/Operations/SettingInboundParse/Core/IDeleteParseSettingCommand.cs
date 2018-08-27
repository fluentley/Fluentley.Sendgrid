using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.SettingInboundParse.Models;

namespace Fluentley.SendGrid.Operations.SettingInboundParse.Core
{
    public interface IDeleteParseSettingCommand : IContextQuery<IDeleteParseSettingCommand>

    {
        IDeleteParseSettingCommand ByModel(ParseSetting value);
        IDeleteParseSettingCommand ByHostName(string hostName);
    }
}