using System;
using System.Collections.Generic;
using Fluentley.SendGrid.Common.Extensions;
using Fluentley.SendGrid.Operations.EmailOperations.Core;
using Fluentley.SendGrid.Operations.EmailOperations.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.EmailOperations.Options.EmailOptions
{
    internal class RecipientOption : IRecipientOption
    {
        /*[JsonProperty("send_at")]
        internal int? SendAtEpoc;*/

        [JsonProperty("to")]
        internal List<EmailAddress> ToAddresses { get; set; }

        [JsonProperty("cc")]
        internal List<EmailAddress> CcAddresses { get; set; }

        [JsonProperty("bcc")]
        internal List<EmailAddress> BccAddresses { get; set; }

        [JsonProperty("subject")]
        internal string SubjectOEmail { get; set; }

        [JsonProperty("substitutions")]
        internal Dictionary<string, string> Substitutions { get; set; }

        [JsonProperty("custom_args")]
        internal Dictionary<string, string> CustomArguments { get; set; }

        [JsonProperty("headers")]
        internal Dictionary<string, string> Headers { get; set; }

        [JsonIgnore]
        internal DateTime? SendAtDateTime { get; set; }

        [JsonProperty("send_at")]
        internal long? SendAt => SendAtDateTime?.ToUnixTime();

        public IRecipientOption AddTo(string emailAddress, string name = null)
        {
            if (ToAddresses == null)
                ToAddresses = new List<EmailAddress>();

            var toAddress = new EmailAddress(emailAddress, name);
            ToAddresses.Add(toAddress);
            return this;
        }

        public IRecipientOption AddCc(string emailAddress, string name = null)
        {
            if (CcAddresses == null)
                CcAddresses = new List<EmailAddress>();

            var ccAddress = new EmailAddress(emailAddress, name);
            CcAddresses.Add(ccAddress);
            return this;
        }

        public IRecipientOption AddBcc(string emailAddress, string name = null)
        {
            if (BccAddresses == null)
                BccAddresses = new List<EmailAddress>();

            var bccAddress = new EmailAddress(emailAddress, name);
            BccAddresses.Add(bccAddress);
            return this;
        }

        public IRecipientOption Subject(string subject)
        {
            SubjectOEmail = subject;
            return this;
        }

        public IRecipientOption AddSubstitution(string key, string value)
        {
            if (Substitutions == null)
                Substitutions = new Dictionary<string, string>();

            Substitutions.Add(key, value);
            return this;
        }

        public IRecipientOption AddCustomArguments(string key, string value)
        {
            if (CustomArguments == null)
                CustomArguments = new Dictionary<string, string>();

            CustomArguments.Add(key, value);
            return this;
        }

        public IRecipientOption SendAtUtc(DateTime sendAtUtcTime)
        {
            SendAtDateTime = sendAtUtcTime;
            return this;
        }

        public IRecipientOption AddHeader(string key, string value)
        {
            if (Headers == null)
                Headers = new Dictionary<string, string>();

            Headers.Add(key, value);
            return this;
        }
    }
}