using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Alerts.Models;
using Fluentley.SendGrid.Operations.Teammates.Core;

namespace Fluentley.SendGrid.Operations.Teammates.Commands
{
    internal class DenyTeammateAccessRequestCommand : AbstractCommand<string, DenyTeammateAccessRequestCommand>,
        IDenyTeammateAccessRequestCommand,
        ICommand<string>
    {
        public DenyTeammateAccessRequestCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal string Id { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IDenyTeammateAccessRequestCommand, DenyTeammateAccessRequestCommand>(this,
                context => context.DenyTeammateAccessRequestById(Id) /*, context =>
                {
                    var validator = new DenyTeammateAccessRequestCommandValidator(context);
                    return validator.ValidateAsync(Id);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<string, IDenyTeammateAccessRequestCommand, DenyTeammateAccessRequestCommand>(this,
                    context => context.DenyTeammateAccessRequestById(Id) /*, context =>
                    {
                        var validator = new DenyTeammateAccessRequestCommandValidator(context);
                        return validator.ValidateAsync(Id);
                    }*/);
        }

        public IDenyTeammateAccessRequestCommand ById(string id)
        {
            Id = id;
            return this;
        }

        public IDenyTeammateAccessRequestCommand ByModel(Alert model)
        {
            Id = model?.Id;
            return this;
        }

        public IDenyTeammateAccessRequestCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}