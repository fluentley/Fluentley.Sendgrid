using System;
using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.EmailOperations.Core
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
}