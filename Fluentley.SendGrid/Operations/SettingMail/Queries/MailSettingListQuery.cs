using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SettingMail.Models;

namespace Fluentley.SendGrid.Operations.SettingMail.Queries
{
    public interface IMailSettingListQuery : IListMemoryFilterQuery<IMailSettingListQuery, MailSetting>,
        IContextQuery<IMailSettingListQuery>
    {
        IMailSettingListQuery UsePaging(int pageIndex, int pageSize);
    }

    internal class MailSettingListQuery : AbstractListQuery<MailSetting>, IMailSettingListQuery,
        IQuery<List<MailSetting>>
    {
        public MailSettingListQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal int? PageSize { get; set; }

        internal int? PageIndex { get; set; }
        internal string MailSetting { get; set; }

        public IMailSettingListQuery UseInMemoryQuery(Action<IQueryOption<MailSetting>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public IMailSettingListQuery UsePaging(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            return this;
        }

        public IMailSettingListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<IResult<List<MailSetting>>> Execute()
        {
            return QueryProcessor.Process<MailSetting, IMailSettingListQuery, MailSettingListQuery>(this,
                context => context.MailSettings(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<MailSetting, IMailSettingListQuery, MailSettingListQuery>(this,
                context => context.MailSettings(this));
        }
    }
}