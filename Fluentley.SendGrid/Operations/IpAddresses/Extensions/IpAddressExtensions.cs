using Fluentley.SendGrid.Operations.IpAddresses.Models;

namespace Fluentley.SendGrid.Operations.IpAddresses.Extensions
{
    internal static class IpAddressExtensions
    {
        public static string ToText(this SortDirection direction)
        {
            switch (direction)
            {
                default:
                case SortDirection.None:
                    return null;
                case SortDirection.Ascending:
                    return "asc";
                case SortDirection.Descending:
                    return "desc";
            }
        }
    }
}