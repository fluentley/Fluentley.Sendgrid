using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Extensions;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.EmailOperations.Models;
using Fluentley.SendGrid.Operations.EmailOperations.Options;
using Fluentley.SendGrid.Operations.EmailOperations.Options.EmailOptions;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.EmailOperations
{
    public interface ISendEmailCommand : IContextQuery<ISendEmailCommand>
    {
        ISendEmailCommand From(string emailAddress, string name = null);
        ISendEmailCommand ReplyTo(string emailAddress, string name = null);
        ISendEmailCommand AddRecipient(Action<IRecipientOption> option);
        ISendEmailCommand Subject(string subject);
        ISendEmailCommand AddSection(string key, string value);
        ISendEmailCommand AddCategory(string name);
        ISendEmailCommand AddCustomArguments(string key, string value);

        ISendEmailCommand MailingSettings(Action<IMailSettingsOption> option);
        ISendEmailCommand TrackingSettings(Action<ITrackingSettingOption> option);
        ISendEmailCommand TemplateId(string value);
        ISendEmailCommand AddHeader(string key, string value);
        ISendEmailCommand AddContentOption(Action<IContentOption> option);
        ISendEmailCommand AddAttachments(Action<IAttachmentOption> option);

        ISendEmailCommand FromIpPoolName(string name);
        ISendEmailCommand Sandbox(Action<ISandboxOption> option);
        ISendEmailCommand UnsubscribeManagement(Action<IUnsubscribeManagementOption> option);
        ISendEmailCommand SendAtUtc(DateTime sendAtDateTime);
    }

    internal class SendEmailCommand : AbstractCommand<string, SendEmailCommand>, ISendEmailCommand, ICommand<string>
    {
        public SendEmailCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("categories")]
        internal List<string> Categories { get; set; }

        [JsonProperty("from")]
        internal EmailAddress FromEmailAddress { get; set; }

        [JsonProperty("reply_to")]
        internal EmailAddress ReplyToEmailAddress { get; set; }

        [JsonProperty("personalizations")]
        internal List<RecipientOption> RecipientOptions { get; set; }

        [JsonProperty("content")]
        internal List<ContentOption> ContentOptions { get; set; }

        [JsonProperty("attachments")]
        internal List<AttachmentOption> AttachmentOptions { get; set; }

        [JsonProperty("sections")]
        internal Dictionary<string, string> Sections { get; set; }

        [JsonProperty("custom_args")]
        internal Dictionary<string, string> CustomArguments { get; set; }

        [JsonProperty("subject")]
        internal string SubjectOfEmail { get; set; }

        [JsonIgnore]
        internal DateTime? SendAtDateTime { get; set; }

        [JsonProperty("send_at")]
        internal long? SendAt => SendAtDateTime?.ToUnixTime();

        [JsonProperty("mail_settings")]
        internal MailSettingsOption MailingSettingsOption { get; set; }

        [JsonProperty("tracking_settings")]
        internal TrackingSettingOption TrackingSettingOption { get; set; }

        [JsonProperty("asm")]
        internal UnsubscribeManagementOption UnsubscribeManagementOption { get; set; }

        [JsonProperty("sandbox_mode")]
        internal SandboxOption SandboxOption { get; set; }

        [JsonProperty("headers")]
        internal Dictionary<string, string> Headers { get; set; }

        [JsonProperty("template_id")]
        internal string EmailTemplateId { get; set; }

        [JsonProperty("ip_pool_name")]
        internal string IpPoolName { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, ISendEmailCommand, SendEmailCommand>(this,
                context => context.SendEmail(this) /*, context =>
                {
                    var validator = new SendEmailCommandValidator();
                    return validator.ValidateAsync(this);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, ISendEmailCommand, SendEmailCommand>(this,
                context => context.SendEmail(this) /*, context =>
                {
                    var validator = new SendEmailCommandValidator();
                    return validator.ValidateAsync(this);
                }*/);
        }

        public ISendEmailCommand FromIpPoolName(string name)
        {
            IpPoolName = name;
            return this;
        }

        public ISendEmailCommand From(string emailAddress, string name = null)
        {
            FromEmailAddress = new EmailAddress(emailAddress, name);
            return this;
        }

        public ISendEmailCommand ReplyTo(string emailAddress, string name = null)
        {
            ReplyToEmailAddress = new EmailAddress(emailAddress, name);
            return this;
        }

        public ISendEmailCommand AddRecipient(Action<IRecipientOption> option)
        {
            if (RecipientOptions == null)
                RecipientOptions = new List<RecipientOption>();

            RecipientOptions.Add(OptionProcessor.Process<IRecipientOption, RecipientOption>(option));
            return this;
        }

        public ISendEmailCommand Subject(string subject)
        {
            SubjectOfEmail = subject;
            return this;
        }

        public ISendEmailCommand AddSection(string key, string value)
        {
            if (Sections == null)
                Sections = new Dictionary<string, string>();

            Sections.Add(key, value);
            return this;
        }

        public ISendEmailCommand AddCategory(string name)
        {
            if (Categories == null)
                Categories = new List<string>();

            Categories.Add(name);
            return this;
        }

        public ISendEmailCommand AddCustomArguments(string key, string value)
        {
            if (CustomArguments == null)
                CustomArguments = new Dictionary<string, string>();

            CustomArguments.Add(key, value);
            return this;
        }

        public ISendEmailCommand SendAtUtc(DateTime sendAtDateTime)
        {
            SendAtDateTime = sendAtDateTime;

            return this;
        }

        public ISendEmailCommand MailingSettings(Action<IMailSettingsOption> option)
        {
            MailingSettingsOption = OptionProcessor.Process<IMailSettingsOption, MailSettingsOption>(option);
            return this;
        }

        public ISendEmailCommand UnsubscribeManagement(Action<IUnsubscribeManagementOption> option)
        {
            UnsubscribeManagementOption =
                OptionProcessor.Process<IUnsubscribeManagementOption, UnsubscribeManagementOption>(option);
            return this;
        }

        public ISendEmailCommand TrackingSettings(Action<ITrackingSettingOption> option)
        {
            TrackingSettingOption = OptionProcessor.Process<ITrackingSettingOption, TrackingSettingOption>(option);
            return this;
        }

        public ISendEmailCommand TemplateId(string value)
        {
            EmailTemplateId = value;
            return this;
        }

        public ISendEmailCommand AddHeader(string key, string value)
        {
            if (Headers == null)
                Headers = new Dictionary<string, string>();

            Headers.Add(key, value);
            return this;
        }

        public ISendEmailCommand AddContentOption(Action<IContentOption> option)
        {
            if (ContentOptions == null)
                ContentOptions = new List<ContentOption>();

            ContentOptions.Add(OptionProcessor.Process<IContentOption, ContentOption>(option));
            return this;
        }

        public ISendEmailCommand Sandbox(Action<ISandboxOption> option)
        {
            SandboxOption = OptionProcessor.Process<ISandboxOption, SandboxOption>(option);
            return this;
        }

        public ISendEmailCommand AddAttachments(Action<IAttachmentOption> option)
        {
            if (AttachmentOptions == null)
                AttachmentOptions = new List<AttachmentOption>();

            AttachmentOptions.Add(OptionProcessor.Process<IAttachmentOption, AttachmentOption>(option));
            return this;
        }

        public ISendEmailCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}