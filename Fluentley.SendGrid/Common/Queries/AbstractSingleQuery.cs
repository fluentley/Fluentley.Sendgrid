using System;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Processors;

namespace Fluentley.SendGrid.Common.Queries
{
    internal abstract class AbstractSingleQuery<T>
    {
        internal ContextOption ContextOption;
        internal Action<IContextOption> ContextOptionAction;
        internal OptionProcessor OptionProcessor;
        internal QueryProcessor QueryProcessor;
        internal QueryRequestGenerator RequestGenerator;

        public AbstractSingleQuery(string defaultApiKey)
        {
            QueryProcessor = new QueryProcessor(defaultApiKey);
            OptionProcessor = new OptionProcessor();
            RequestGenerator = new QueryRequestGenerator(defaultApiKey);
        }
    }
}