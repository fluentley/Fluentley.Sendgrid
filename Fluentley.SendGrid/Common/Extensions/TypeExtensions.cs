using System;
using System.Linq;

namespace Fluentley.SendGrid.Common.Extensions
{
    internal static class TypeExtensions
    {
        public static Type DelaredGenericType(this Type type)
        {
            return type.GenericTypeArguments.Any() ? DelaredGenericType(type.GenericTypeArguments[0]) : type;
        }
    }
}