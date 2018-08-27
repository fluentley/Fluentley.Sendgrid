using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.BouncedEmailAddresses.Commands
{
    public interface IDeleteBouncedEmailAddressCommand : IContextQuery<IDeleteBouncedEmailAddressCommand>

    {
        IDeleteBouncedEmailAddressCommand DeleteAll(bool value);
        IDeleteBouncedEmailAddressCommand AddForDeletion(params string[] values);
    }

    internal class DeleteBouncedEmailAddressCommand : AbstractCommand<string, DeleteBouncedEmailAddressCommand>,
        IDeleteBouncedEmailAddressCommand,
        ICommand<string>

    {
        public DeleteBouncedEmailAddressCommand(string defaultApiKey) : base(defaultApiKey)
        {
            EmailAddresses = new List<string>();
        }

        [JsonProperty("emails")]
        public List<string> EmailAddresses { get; set; }

        [JsonProperty("delete_all")]
        public bool ShouldDeleteAll { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IDeleteBouncedEmailAddressCommand, DeleteBouncedEmailAddressCommand>(this,
                context => context.DeleteBouncedEmailAddress(this) /*, context =>
                {
                    var validator = new DeleteBouncedEmailAddressCommandValidator(context);
                    return validator.ValidateAsync(this);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<string, IDeleteBouncedEmailAddressCommand, DeleteBouncedEmailAddressCommand>(this,
                    context => context.DeleteBouncedEmailAddress(this) /*, context =>
                    {
                        var validator = new DeleteBouncedEmailAddressCommandValidator(context);
                        return validator.ValidateAsync(this);
                    }*/);
        }

        public IDeleteBouncedEmailAddressCommand DeleteAll(bool value)
        {
            ShouldDeleteAll = value;
            return this;
        }

        public IDeleteBouncedEmailAddressCommand AddForDeletion(params string[] values)
        {
            if (EmailAddresses == null)
                EmailAddresses = new List<string>();

            if (values.Any())
                EmailAddresses.AddRange(values);

            return this;
        }

        public IDeleteBouncedEmailAddressCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}