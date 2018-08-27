using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Fluentley.SendGrid.Operations.ApiKeys.Models;

namespace Fluentley.SendGrid.Operations.ApiKeys.Extensions
{
    internal static class ApiKeyExtensions
    {
        public static string DisplayName(this Enum value)
        {
            var enumType = value.GetType();
            var enumValue = Enum.GetName(enumType, value);
            var member = enumType.GetMember(enumValue)[0];

            var selectedAttributes = member.GetCustomAttributes(typeof(DisplayAttribute), false);
            var stringValue = ((DisplayAttribute) selectedAttributes[0]).Name;

            if (((DisplayAttribute) selectedAttributes[0]).ResourceType != null)
                stringValue = ((DisplayAttribute) selectedAttributes[0]).GetName();

            return stringValue;
        }

        public static Scope ConvertToScope(this string scopeString)
        {
            return Enum.GetValues(typeof(Scope)).Cast<Scope>().FirstOrDefault(x => x.DisplayName() == scopeString);
        }
    }
}