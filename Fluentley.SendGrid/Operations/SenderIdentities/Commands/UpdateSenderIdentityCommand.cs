using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.EmailOperations.Models;
using Fluentley.SendGrid.Operations.SenderIdentities.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.SenderIdentities.Commands
{
    public interface IUpdateSenderIdentityCommand : IContextQuery<IUpdateSenderIdentityCommand>

    {
        IUpdateSenderIdentityCommand ByModel(SenderIdentity senderIdentity);
    }

    internal class UpdateSenderIdentityCommand : AbstractCommand<SenderIdentity, UpdateSenderIdentityCommand>,
        IUpdateSenderIdentityCommand,
        ICommand<SenderIdentity>
    {
        public UpdateSenderIdentityCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("id")]
        internal string Id { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("from")]
        public EmailAddress From { get; set; }

        [JsonProperty("reply_to")]
        public EmailAddress ReplyTo { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("address_2")]
        public string Address2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("verified")]
        public bool? Verified { get; set; }

        [JsonProperty("locked")]
        public bool? Locked { get; set; }

        public Task<IResult<SenderIdentity>> Execute()
        {
            return Processor.Process<SenderIdentity, IUpdateSenderIdentityCommand, UpdateSenderIdentityCommand>(this,
                context => context.UpdateSenderIdentity(this) /*, context =>
                {
                    var validator = new UpdateSenderIdentityCommandValidator(context);
                    return validator.ValidateAsync(this);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<SenderIdentity, IUpdateSenderIdentityCommand, UpdateSenderIdentityCommand>(
                this,
                context => context.UpdateSenderIdentity(this) /*, context =>
                {
                    var validator = new UpdateSenderIdentityCommandValidator(context);
                    return validator.ValidateAsync(this);
                }*/);
        }

        public IUpdateSenderIdentityCommand ByModel(SenderIdentity senderIdentity)
        {
            Id = senderIdentity.Id;
            Locked = senderIdentity.Locked;
            Verified = senderIdentity.Verified;
            Country = senderIdentity.Country;
            Zip = senderIdentity.Zip;
            State = senderIdentity.State;
            City = senderIdentity.City;
            Address2 = senderIdentity.Address2;
            Address = senderIdentity.Address;
            ReplyTo = senderIdentity.ReplyTo;
            From = senderIdentity.From;
            Nickname = senderIdentity.Nickname;
            return this;
        }

        public IUpdateSenderIdentityCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}