using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Users.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Users.Commands
{
    public interface IUpdateUserNameCommand : IContextQuery<IUpdateUserNameCommand>

    {
        IUpdateUserNameCommand ByModel(User userName);
    }

    internal class UpdateUserNameCommand : AbstractCommand<User, UpdateUserNameCommand>, IUpdateUserNameCommand,
        ICommand<User>
    {
        public UpdateUserNameCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("username")]
        internal string UserName { get; set; }

        public Task<IResult<User>> Execute()
        {
            return Processor.Process<User, IUpdateUserNameCommand, UpdateUserNameCommand>(this,
                context => context.UpdateUserName(this) /*, context =>
                {
                    var validator = new UpdateUserNameCommandValidator(context);
                    return validator.ValidateAsync(this);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<User, IUpdateUserNameCommand, UpdateUserNameCommand>(this,
                context => context.UpdateUserName(this) /*, context =>
                {
                    var validator = new UpdateUserNameCommandValidator(context);
                    return validator.ValidateAsync(this);
                }*/);
        }

        public IUpdateUserNameCommand ByModel(User user)
        {
            UserName = user.UserName;

            return this;
        }

        public IUpdateUserNameCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}