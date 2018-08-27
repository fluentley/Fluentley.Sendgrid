using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SubUsers.Core;

namespace Fluentley.SendGrid.Operations.SubUsers.Commands
{
    internal class DeleteSubUserCommand : AbstractCommand<string, DeleteSubUserCommand>, IDeleteSubUserCommand,
        ICommand<string>
    {
        private readonly string _defaultApiKey;

        public DeleteSubUserCommand(string defaultApiKey) : base(defaultApiKey)
        {
            _defaultApiKey = defaultApiKey;
        }

        public string SubUserName { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IDeleteSubUserCommand, DeleteSubUserCommand>(this,
                context => context.DeleteSubUserById(SubUserName) /*, context =>
                {
                    var validator = new DeleteSubUserCommandValidator(_defaultApiKey, context);
                    return validator.ValidateAsync(options => options
                        .FilterBySubUserName(SubUserName)
                        .UsePaging(0, 1));
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IDeleteSubUserCommand, DeleteSubUserCommand>(this,
                context => context.DeleteSubUserById(SubUserName) /*, context =>
                {
                    var validator = new DeleteSubUserCommandValidator(_defaultApiKey, context);
                    return validator.ValidateAsync(options => options
                        .FilterBySubUserName(SubUserName)
                        .UsePaging(0, 1));
                }*/);
        }

        public IDeleteSubUserCommand BySubUserName(string subUserName)
        {
            SubUserName = subUserName;
            return this;
        }

        public IDeleteSubUserCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}