using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Teammates.Core;
using Fluentley.SendGrid.Operations.Teammates.Models;

namespace Fluentley.SendGrid.Operations.Teammates.Commands
{
    internal class ApproveTeammateAccessRequestCommand :
        AbstractCommand<ApproveTeammateRequestResult, ApproveTeammateAccessRequestCommand>,
        IApproveTeammateAccessRequestCommand,
        ICommand<ApproveTeammateRequestResult>
    {
        public ApproveTeammateAccessRequestCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal string Id { get; set; }

        public IApproveTeammateAccessRequestCommand ById(string id)
        {
            Id = id;
            return this;
        }

        public IApproveTeammateAccessRequestCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<IResult<ApproveTeammateRequestResult>> Execute()
        {
            return Processor
                .Process<ApproveTeammateRequestResult, IApproveTeammateAccessRequestCommand,
                    ApproveTeammateAccessRequestCommand>(this,
                    context => context.ApproveTeammateAccessRequestById(Id) /*, context =>
                    {
                        var validator = new ApproveTeammateAccessRequestCommandValidator(context);
                        return validator.ValidateAsync(Id);
                    }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<ApproveTeammateRequestResult, IApproveTeammateAccessRequestCommand,
                    ApproveTeammateAccessRequestCommand>(this,
                    context => context.ApproveTeammateAccessRequestById(Id) /*, context =>
                    {
                        var validator = new ApproveTeammateAccessRequestCommandValidator(context);
                        return validator.ValidateAsync(Id);
                    }*/);
        }
    }
}