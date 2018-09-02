using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Alerts.Core.Queries;
using Fluentley.SendGrid.Operations.Alerts.Models;

namespace Fluentley.SendGrid.Operations.Alerts.Queries
{
    internal class AlertSingleQuery : AbstractSingleQuery<Alert>, IAlertSingleQuery, IQuery<Alert>
    {
        public AlertSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private string Id { get; set; }

        public IAlertSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IAlertSingleQuery ById(string id)
        {
            Id = id;
            return this;
        }

        public Task<IResult<Alert>> Execute()
        {
            return QueryProcessor.Process<Alert, IAlertSingleQuery, AlertSingleQuery>(this,
                context => context.AlertById(Id));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<Alert, IAlertSingleQuery, AlertSingleQuery>(this,
                context => context.AlertById(Id));
        }
    }
}