using System;
using System.Threading.Tasks;
using Fluentley.QueryBuilder.Options;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Processors;
using Newtonsoft.Json;

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

    internal abstract class AbstractCommand<T, TCommand> where TCommand : ICommand<T>
    {
        internal ContextOption ContextOption;
        internal Action<IContextOption> ContextOptionAction;
        internal OptionProcessor OptionProcessor;
        internal CommandProcessor Processor;
        internal CommandRequestGenerator RequestGenerator;

        public AbstractCommand(string defaultApiKey)
        {
            Processor = new CommandProcessor(defaultApiKey);
            OptionProcessor = new OptionProcessor();
            RequestGenerator = new CommandRequestGenerator(defaultApiKey);
        }

        public Task<IResult<T>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<TCommand>(commandJson);
            return command.Execute();
        }
    }
}