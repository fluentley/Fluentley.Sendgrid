namespace Fluentley.SendGrid.Operations.EmailOperations.Core
{
    public interface IContentOption
    {
        IContentOption Type(string value);
        IContentOption Value(string value);
    }
}