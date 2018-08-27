namespace Fluentley.SendGrid.Operations.EmailOperations.Core
{
    public interface ISpamCheckOption
    {
        ISpamCheckOption Enable(bool value);
        ISpamCheckOption Treshold(int value);
        ISpamCheckOption PostReportToUrl(string value);
    }
}