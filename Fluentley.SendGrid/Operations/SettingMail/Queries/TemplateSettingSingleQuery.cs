using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SettingMail.Models;

namespace Fluentley.SendGrid.Operations.SettingMail.Queries
{
    public interface ITemplateSettingSingleQuery : IContextQuery<ITemplateSettingSingleQuery>

    {
    }

    internal class TemplateSettingSingleQuery : AbstractSingleQuery<TemplateSetting>, ITemplateSettingSingleQuery,
        IQuery<TemplateSetting>
    {
        public TemplateSettingSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public Task<IResult<TemplateSetting>> Execute()
        {
            return QueryProcessor.Process<TemplateSetting, ITemplateSettingSingleQuery, TemplateSettingSingleQuery>(
                this,
                context => context.TemplateSetting());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<TemplateSetting, ITemplateSettingSingleQuery, TemplateSettingSingleQuery>(
                this,
                context => context.TemplateSetting());
        }

        public ITemplateSettingSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}