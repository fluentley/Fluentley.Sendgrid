using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Alerts.Models;

namespace Fluentley.SendGrid.Operations.Alerts.Queries
{
    public interface IAlertListQuery : IListMemoryFilterQuery<IAlertListQuery, Alert>, IContextQuery<IAlertListQuery>
    {
    }

    internal class AlertListQuery : AbstractListQuery<Alert>, IAlertListQuery,
        IQuery<List<Alert>>
    {
        public AlertListQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public IAlertListQuery UseInMemoryQuery(Action<IQueryOption<Alert>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public IAlertListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<IResult<List<Alert>>> Execute()
        {
            return QueryProcessor.Process<Alert, IAlertListQuery, AlertListQuery>(this, context => context.Alerts());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<Alert, IAlertListQuery, AlertListQuery>(this, context => context.Alerts());
        }
    }
}