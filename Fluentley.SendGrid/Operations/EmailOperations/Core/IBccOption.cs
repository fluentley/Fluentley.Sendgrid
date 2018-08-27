namespace Fluentley.SendGrid.Operations.EmailOperations.Core
{
    public interface IBccOption
    {
        IBccOption Enable(bool value);
        IBccOption EmaiLAddress(string value);
    }
}