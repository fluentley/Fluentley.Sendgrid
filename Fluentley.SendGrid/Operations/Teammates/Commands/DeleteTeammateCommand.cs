using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Teammates.Models;

namespace Fluentley.SendGrid.Operations.Teammates.Commands
{
    public interface IDeleteTeammateCommand : IContextQuery<IDeleteTeammateCommand>

    {
        IDeleteTeammateCommand ByUserName(string userName);
        IDeleteTeammateCommand ByModel(Teammate model);
    }

    internal class DeleteTeammateCommand : AbstractCommand<string, DeleteTeammateCommand>, IDeleteTeammateCommand,
        ICommand<string>
    {
        public DeleteTeammateCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal string UserName { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IDeleteTeammateCommand, DeleteTeammateCommand>(this,
                context => context.DeleteTeammateByUserName(UserName) /*, context =>
                {
                    var validator = new DeleteTeammateCommandValidator(context);
                    return validator.ValidateAsync(UserName);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IDeleteTeammateCommand, DeleteTeammateCommand>(this,
                context => context.DeleteTeammateByUserName(UserName) /*, context =>
                {
                    var validator = new DeleteTeammateCommandValidator(context);
                    return validator.ValidateAsync(UserName);
                }*/);
        }

        public IDeleteTeammateCommand ByUserName(string userName)
        {
            UserName = userName;
            return this;
        }

        public IDeleteTeammateCommand ByModel(Teammate model)
        {
            UserName = model?.Username;
            return this;
        }

        public IDeleteTeammateCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}