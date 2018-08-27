using System;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Processors;

namespace Fluentley.SendGrid.Common.Queries
{
    internal abstract class AbstractListQuery<T> where T : class
    {
        internal ContextOption ContextOption;
        internal Action<IContextOption> ContextOptionAction;
        internal OptionProcessor OptionProcessor;
        internal Action<IQueryOption<T>> QueryOptionAction;
        internal QueryProcessor QueryProcessor;
        internal QueryRequestGenerator RequestGenerator;

        public AbstractListQuery(string defaultApiKey)
        {
            QueryProcessor = new QueryProcessor(defaultApiKey);
            OptionProcessor = new OptionProcessor();
            RequestGenerator = new QueryRequestGenerator(defaultApiKey);
        }
    }
}