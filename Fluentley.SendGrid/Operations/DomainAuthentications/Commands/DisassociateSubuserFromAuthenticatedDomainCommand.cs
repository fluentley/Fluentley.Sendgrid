using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.DomainAuthentications.Core;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Commands
{
    internal class DisassociateSubUserFromAuthenticatedDomainCommand :
        AbstractCommand<string, DisassociateSubUserFromAuthenticatedDomainCommand>,
        IDisassociateSubUserFromAuthenticatedDomainCommand, ICommand<string>
    {
        public DisassociateSubUserFromAuthenticatedDomainCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public Task<IResult<string>> Execute()
        {
            return Processor
                .Process<string, IDisassociateSubUserFromAuthenticatedDomainCommand,
                    DisassociateSubUserFromAuthenticatedDomainCommand>(this,
                    context => context.DisassociateSubuserFromAuthenticatedDomain());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<string, IDisassociateSubUserFromAuthenticatedDomainCommand,
                    DisassociateSubUserFromAuthenticatedDomainCommand>(this,
                    context => context.DisassociateSubuserFromAuthenticatedDomain());
        }

        public IDisassociateSubUserFromAuthenticatedDomainCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}