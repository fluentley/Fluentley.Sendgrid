using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.LinkBrandings.Core;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Commands
{
    internal class DisassociateBrandedForSubUserCommand : AbstractCommand<string, DisassociateBrandedForSubUserCommand>,
        IDisassociateBrandedForSubUserCommand,
        ICommand<string>
    {
        public DisassociateBrandedForSubUserCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal string UserName { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor
                .Process<string, IDisassociateBrandedForSubUserCommand, DisassociateBrandedForSubUserCommand>(this,
                    context => context.DisassociateBrandedForSubUser(UserName) /*, context =>
                    {
                        var validator = new DisassociateBrandedForSubUserCommandValidator(context);
                        return validator.ValidateAsync(UserName);
                    }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<string, IDisassociateBrandedForSubUserCommand, DisassociateBrandedForSubUserCommand>(this,
                    context => context.DisassociateBrandedForSubUser(UserName) /*, context =>
                    {
                        var validator = new DisassociateBrandedForSubUserCommandValidator(context);
                        return validator.ValidateAsync(UserName);
                    }*/);
        }

        public IDisassociateBrandedForSubUserCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IDisassociateBrandedForSubUserCommand SubUserName(string value)
        {
            UserName = value;
            return this;
        }
    }
}