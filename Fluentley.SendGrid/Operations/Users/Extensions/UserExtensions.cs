using Fluentley.SendGrid.Operations.Users.Models;

namespace Fluentley.SendGrid.Operations.Users.Extensions
{
    internal static class UserExtensions
    {
        public static string ToAccountType(this AccountType value)
        {
            switch (value)
            {
                default:
                    return "undefined";
                case AccountType.Free:
                    return "free";

                case AccountType.Paid:
                    return "paid";
            }
        }
    }
}