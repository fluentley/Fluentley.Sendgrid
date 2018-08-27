using System;

namespace Fluentley.SendGrid.Operations.EmailOperations.Core
{
    public interface IMailSettingsOption
    {
        IMailSettingsOption Bcc(Action<IBccOption> option);
        IMailSettingsOption AllowBypassListManagement(Action<IBypassListManagementOption> option);
        IMailSettingsOption SandboxMode(bool value);
        IMailSettingsOption SpamCheck(Action<ISpamCheckOption> option);
        IMailSettingsOption Footer(Action<IFooterOption> option);
    }
}