using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;

namespace Fluentley.SendGrid.Operations.ReverseDnses.Commands
{
    public interface IDeleteReverseDnsCommand : IContextQuery<IDeleteReverseDnsCommand>

    {
        IDeleteReverseDnsCommand ById(string id);
    }

    internal class DeleteReverseDnsCommand : AbstractCommand<string, DeleteReverseDnsCommand>, IDeleteReverseDnsCommand,
        ICommand<string>
    {
        public DeleteReverseDnsCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public string Id { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IDeleteReverseDnsCommand, DeleteReverseDnsCommand>(this,
                context => context.DeleteReverseDns(Id));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IDeleteReverseDnsCommand, DeleteReverseDnsCommand>(this,
                context => context.DeleteReverseDns(Id));
        }

        public IDeleteReverseDnsCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IDeleteReverseDnsCommand ById(string id)
        {
            Id = id;
            return this;
        }
    }
}