using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.SettingMail.Models;

namespace Fluentley.SendGrid.Operations.SettingMail.Core
{
    public interface IMailSettingListQuery : IListMemoryFilterQuery<IMailSettingListQuery, MailSetting>,
        IContextQuery<IMailSettingListQuery>
    {
        IMailSettingListQuery UsePaging(int pageIndex, int pageSize);
    }
}