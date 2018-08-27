namespace Fluentley.SendGrid.Operations.EmailOperations.Core
{
    public interface IUnsubscribeManagementOption
    {
        IUnsubscribeManagementOption GroupId(string value);
        IUnsubscribeManagementOption AddUnsubscribesGroupsToDisplay(params int[] values);
    }
}