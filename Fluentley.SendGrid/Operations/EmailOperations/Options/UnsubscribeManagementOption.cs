using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.EmailOperations.Options
{
    public interface IUnsubscribeManagementOption
    {
        IUnsubscribeManagementOption GroupId(string value);
        IUnsubscribeManagementOption AddUnsubscribesGroupsToDisplay(params int[] values);
    }

    internal class UnsubscribeManagementOption : IUnsubscribeManagementOption
    {
        [JsonProperty("group_id")]
        internal string UnsubscribeGroupId { get; set; }

        [JsonProperty("groups_to_display")]
        internal List<int> UnsubscribesGroupsToDisplay { get; set; }

        public IUnsubscribeManagementOption GroupId(string value)
        {
            UnsubscribeGroupId = value;
            return this;
        }

        public IUnsubscribeManagementOption AddUnsubscribesGroupsToDisplay(params int[] values)
        {
            if (values.Any())
            {
                if (UnsubscribesGroupsToDisplay == null)
                    UnsubscribesGroupsToDisplay = new List<int>();

                UnsubscribesGroupsToDisplay.AddRange(values);
            }

            return this;
        }
    }
}