using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.EmailOperations.Models;
using Fluentley.SendGrid.Operations.SenderIdentities.Core;
using Fluentley.SendGrid.Operations.SenderIdentities.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.SenderIdentities.Commands
{
    internal class CreateSenderIdentityCommand : AbstractCommand<SenderIdentity, CreateSenderIdentityCommand>,
        ICreateSenderIdentityCommand,
        ICommand<SenderIdentity>
    {
        public CreateSenderIdentityCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

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
            return Processor.Process<SenderIdentity, ICreateSenderIdentityCommand, CreateSenderIdentityCommand>(this,
                context => context.CreateSenderIdentity(this) /*, context =>
                {
                    var validator = new CreateSenderIdentityCommandValidator();
                    return validator.ValidateAsync(this);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<SenderIdentity, ICreateSenderIdentityCommand, CreateSenderIdentityCommand>(
                this,
                context => context.CreateSenderIdentity(this) /*, context =>
                {
                    var validator = new CreateSenderIdentityCommandValidator();
                    return validator.ValidateAsync(this);
                }*/);
        }

        public ICreateSenderIdentityCommand ByModel(SenderIdentity senderIdentity)
        {
            if (senderIdentity == null)
                return this;

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

        public ICreateSenderIdentityCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}