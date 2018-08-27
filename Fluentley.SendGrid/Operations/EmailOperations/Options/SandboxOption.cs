using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.EmailOperations.Options
{
    public interface ISandboxOption
    {
        ISandboxOption Enable(bool value);
    }

    internal class SandboxOption : ISandboxOption
    {
        [JsonProperty("enable")]
        internal bool IsEnabled { get; set; }

        public ISandboxOption Enable(bool value)
        {
            IsEnabled = value;
            return this;
        }
    }
}