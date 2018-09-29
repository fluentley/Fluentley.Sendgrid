using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Processors;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Common.Queries
{
    internal abstract class AbstractCommand<T, TCommand> where TCommand : ICommand<T>
    {
        internal ContextOption ContextOption;
        internal OptionProcessor OptionProcessor;
        internal CommandProcessor Processor;
        internal CommandRequestGenerator RequestGenerator;

        public AbstractCommand(string defaultApiKey)
        {
            Processor = new CommandProcessor(defaultApiKey);
            OptionProcessor = new OptionProcessor();
            RequestGenerator = new CommandRequestGenerator(defaultApiKey);
        }
    }
}