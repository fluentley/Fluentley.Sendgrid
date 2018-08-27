namespace Fluentley.SendGrid.Common.Options.ContextOptions
{
    public interface IContextOption
    {
        IContextOption OnBehalfOfSubUser(string value);
        IContextOption UseApiKey(string value);
    }
}