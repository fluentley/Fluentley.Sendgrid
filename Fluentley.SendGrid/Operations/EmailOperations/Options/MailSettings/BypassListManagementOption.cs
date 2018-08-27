using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.EmailOperations.Options.MailSettings
{
    public interface IBypassListManagementOption
    {
        IBypassListManagementOption Enable(bool value);
    }

    internal class BypassListManagementOption : IBypassListManagementOption
    {
        [JsonProperty("enable")]
        internal bool IsEnabled { get; set; }

        public IBypassListManagementOption Enable(bool value)
        {
            IsEnabled = value;
            return this;
        }
    }
}