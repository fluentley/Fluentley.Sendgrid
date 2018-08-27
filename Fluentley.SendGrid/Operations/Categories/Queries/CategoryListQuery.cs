using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Categories.Models;
using Fluentley.SendGrid.Operations.Statistics.Queries;

namespace Fluentley.SendGrid.Operations.Categories.Queries
{
    public interface ICategoryListQuery : IListMemoryFilterQuery<ICategoryListQuery, Category>,
        IContextQuery<ICategoryListQuery>
    {
        ICategoryListQuery UsePaging(int pageIndex, int pageSize);
        ICategoryListQuery FilterByName(string value);
    }

    internal class CategoryListQuery : AbstractListQuery<Category>, ICategoryListQuery, IQuery<List<Category>>
    {
        public CategoryListQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal int? PageSize { get; set; }

        internal int? PageIndex { get; set; }
        internal string Category { get; set; }

        internal EmailStatisticsListQuery EmailStatisticsListQuery { get; set; }

        public ICategoryListQuery UseInMemoryQuery(Action<IQueryOption<Category>> option)
        {
            QueryOptionAction = option;
            return this;
        }

        public ICategoryListQuery UsePaging(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            return this;
        }

        public ICategoryListQuery FilterByName(string value)
        {
            Category = value;
            return this;
        }

        public ICategoryListQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public async Task<IResult<List<Category>>> Execute()
        {
            var result =
                await QueryProcessor.Process<Category, ICategoryListQuery, CategoryListQuery>(this,
                    context => context.Categories(this));

            if (result.IsSuccess && result.Data.Any())
                foreach (var category in result.Data)
                    if (EmailStatisticsListQuery != null)
                    {
                        EmailStatisticsListQuery
                            .UseContextOption(ContextOptionAction)
                            .ForCategory(category.Name);

                        var emailStatisticsResult = await EmailStatisticsListQuery.Execute();

                        if (emailStatisticsResult.IsSuccess)
                            category.EmailStatistics = emailStatisticsResult.Data;
                    }

            return result;
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<Category, ICategoryListQuery, CategoryListQuery>(this,
                context => context.Categories(this));
        }

        public ICategoryListQuery EagerLoadCampaignSchedule(Action<IEmailStatisticsListQuery> queryAction = null)
        {
            EmailStatisticsListQuery =
                OptionProcessor.Process<IEmailStatisticsListQuery, EmailStatisticsListQuery>(queryAction);
            return this;
        }
    }
}