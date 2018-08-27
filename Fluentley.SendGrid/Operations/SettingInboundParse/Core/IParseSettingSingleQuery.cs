using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.SettingInboundParse.Core
{
    public interface IParseSettingSingleQuery : IContextQuery<IParseSettingSingleQuery>

    {
        IParseSettingSingleQuery ByHostName(string value);
    }
}