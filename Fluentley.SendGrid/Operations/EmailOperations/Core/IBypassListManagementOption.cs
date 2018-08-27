namespace Fluentley.SendGrid.Operations.EmailOperations.Core
{
    public interface IBypassListManagementOption
    {
        IBypassListManagementOption Enable(bool value);
    }
}