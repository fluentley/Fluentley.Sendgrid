using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.LinkBrandings.Core;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Commands
{
    internal class AssociateBrandedForSubUserCommand : AbstractCommand<string, AssociateBrandedForSubUserCommand>,
        IAssociateBrandedForSubUserCommand,
        ICommand<string>
    {
        public AssociateBrandedForSubUserCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("id")]
        internal string Id { get; set; }

        [JsonProperty("username")]
        internal string SubUser { get; set; }

        public IAssociateBrandedForSubUserCommand BrandedLinkId(string id)
        {
            Id = id;
            return this;
        }

        public IAssociateBrandedForSubUserCommand SubUserName(string subUserName)
        {
            SubUser = subUserName;
            return this;
        }

        public IAssociateBrandedForSubUserCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IAssociateBrandedForSubUserCommand, AssociateBrandedForSubUserCommand>(
                this,
                context => context.AssociateBrandedForSubUser(this) /*, context =>
                {
                    var validator = new AssociateBrandedForSubUserCommandValidator(context);
                    return validator.ValidateAsync(Id);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<string, IAssociateBrandedForSubUserCommand, AssociateBrandedForSubUserCommand>(
                    this,
                    context => context.AssociateBrandedForSubUser(this) /*, context =>
                    {
                        var validator = new AssociateBrandedForSubUserCommandValidator(context);
                        return validator.ValidateAsync(Id);
                    }*/);
        }
    }
}