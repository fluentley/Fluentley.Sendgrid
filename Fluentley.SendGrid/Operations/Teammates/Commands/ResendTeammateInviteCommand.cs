﻿using System;
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
    internal class ResendTeammateInviteCommand : AbstractCommand<TeammateInviteResult, ResendTeammateInviteCommand>,
        IResendTeammateInviteCommand,
        ICommand<TeammateInviteResult>
    {
        public ResendTeammateInviteCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal string Token { get; set; }

        public Task<IResult<TeammateInviteResult>> Execute()
        {
            return Processor.Process<TeammateInviteResult, IResendTeammateInviteCommand, ResendTeammateInviteCommand>(
                this,
                context => context.ResendTeammateInviteByToken(Token) /*, context =>
                {
                    var validator = new ResendTeammateInviteCommandValidator(context);
                    return validator.ValidateAsync(Token);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<TeammateInviteResult, IResendTeammateInviteCommand, ResendTeammateInviteCommand>(
                    this,
                    context => context.ResendTeammateInviteByToken(Token) /*, context =>
                    {
                        var validator = new ResendTeammateInviteCommandValidator(context);
                        return validator.ValidateAsync(Token);
                    }*/);
        }

        public IResendTeammateInviteCommand ByToken(string value)
        {
            Token = value;
            return this;
        }

        public IResendTeammateInviteCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}