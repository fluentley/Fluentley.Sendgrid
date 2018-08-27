using Fluentley.SendGrid.Operations.EmailOperations.Core;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.EmailOperations.Options
{
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