using Fluentley.SendGrid.Contexts;

namespace Fluentley.SendGrid.Common.Options.ContextOptions
{
    internal class ContextOption : IContextOption
    {
        public string ApiKey { get; set; }
        public string OnBeHalfOf { get; set; }

        public IContextOption OnBehalfOfSubUser(string value)
        {
            ApiKey = value;
            return this;
        }

        public IContextOption UseApiKey(string value)
        {
            OnBeHalfOf = value;
            return this;
        }

        public Context Process(Context context)
        {
            if (!string.IsNullOrWhiteSpace(OnBeHalfOf))
                context.SetOnBehalfOf(OnBeHalfOf);

            if (!string.IsNullOrWhiteSpace(ApiKey))
                context.SetApiKey(ApiKey);

            return context;
        }
    }
}