using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.SettingInboundParse.Models;

namespace Fluentley.SendGrid.Operations.SettingInboundParse.Core
{
    public interface IParseSettingListQuery : IListMemoryFilterQuery<IParseSettingListQuery, ParseSetting>,
        IContextQuery<IParseSettingListQuery>
    {
    }
}