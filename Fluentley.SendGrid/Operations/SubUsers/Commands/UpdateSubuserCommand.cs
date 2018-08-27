using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.SubUsers.Models;

namespace Fluentley.SendGrid.Operations.SubUsers.Commands
{
    public interface IUpdateSubUserCommand : IContextQuery<IUpdateSubUserCommand>

    {
        IUpdateSubUserCommand ByModel(SubUser subUser);
    }

    internal class UpdateSubUserCommand : AbstractCommand<SubUser, UpdateSubUserCommand>, IUpdateSubUserCommand,
        ICommand<SubUser>
    {
        private readonly string _defaultApiKey;

        public UpdateSubUserCommand(string defaultApiKey) : base(defaultApiKey)
        {
            _defaultApiKey = defaultApiKey;
        }

        internal SubUser Model { get; set; }

        public Task<IResult<SubUser>> Execute()
        {
            return Processor.Process<SubUser, IUpdateSubUserCommand, UpdateSubUserCommand>(this,
                context => context.UpdateSubUser(Model) /*, context =>
                {
                    var validator = new UpdateSubUserCommandValidator(_defaultApiKey, context);
                    return validator.ValidateAsync(x => x.FilterBySubUserName(Model.UserName));
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<SubUser, IUpdateSubUserCommand, UpdateSubUserCommand>(this,
                context => context.UpdateSubUser(Model) /*, context =>
                {
                    var validator = new UpdateSubUserCommandValidator(_defaultApiKey, context);
                    return validator.ValidateAsync(x => x.FilterBySubUserName(Model.UserName));
                }*/);
        }

        public IUpdateSubUserCommand ByModel(SubUser subUser)
        {
            Model = subUser;
            return this;
        }

        public IUpdateSubUserCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}