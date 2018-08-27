using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;

namespace Fluentley.SendGrid.Operations.SubUsers.Commands
{
    public interface IEnableOrDisableSubUserCommand : IContextQuery<IEnableOrDisableSubUserCommand>

    {
        IEnableOrDisableSubUserCommand Disable(string subUserName, bool value);
    }

    internal class EnableOrDisableSubUserCommand : AbstractCommand<string, EnableOrDisableSubUserCommand>,
        IEnableOrDisableSubUserCommand,
        ICommand<string>
    {
        private readonly string _defaultApiKey;

        public EnableOrDisableSubUserCommand(string defaultApiKey) : base(defaultApiKey)
        {
            _defaultApiKey = defaultApiKey;
        }

        internal string SubUserName { get; set; }

        internal bool IsDisabled { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IEnableOrDisableSubUserCommand, EnableOrDisableSubUserCommand>(this,
                context => context.EnableOrDisableSubUser(SubUserName, IsDisabled) /*, context =>
                {
                    var validator = new EnabledOrDisableSubUserCommandValidator(_defaultApiKey, context);
                    return validator.ValidateAsync(options => options
                        .FilterBySubUserName(SubUserName)
                        .UsePaging(0, 1));
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IEnableOrDisableSubUserCommand, EnableOrDisableSubUserCommand>(
                this,
                context => context.EnableOrDisableSubUser(SubUserName, IsDisabled) /*, context =>
                {
                    var validator = new EnabledOrDisableSubUserCommandValidator(_defaultApiKey, context);
                    return validator.ValidateAsync(options => options
                        .FilterBySubUserName(SubUserName)
                        .UsePaging(0, 1));
                }*/);
        }

        public IEnableOrDisableSubUserCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IEnableOrDisableSubUserCommand Disable(string subUserName, bool value)
        {
            SubUserName = subUserName;
            IsDisabled = value;
            return this;
        }
    }
}