namespace Fluentley.SendGrid.Operations.EmailOperations.Core
{
    public interface IFooterOption
    {
        IFooterOption ContentText(string value);
        IFooterOption ContentHtml(string value);
    }
}