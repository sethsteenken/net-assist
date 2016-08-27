using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace NetAssist
{
    public static class EnumerableExtensions
    {
        public static bool AnyNull(this IEnumerable enumerable)
        {
            foreach (var item in enumerable)
            {
                if (item == null)
                    return true;
            }
            return false;
        }

        public static string ToFriendlyName(this Enum value)
        {
            if (value == null)
                return string.Empty;

            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    var attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null && !string.IsNullOrWhiteSpace(attr.Description))
                        return attr.Description;
                }
            }

            return value.ToString();
        }

        public static bool HasItems(this Array array)
        {
            return array != null && array.Length > 0;
        }

        public static bool HasItems<T>(this IEnumerable<T> list)
        {
            return list != null && list.Any();
        }

        public static string ToDelimitedString(this IEnumerable<int> items)
        {
            return ToDelimitedString(items, StringExtensions.DefaultDelimiter);
        }

        public static string ToDelimitedString(this IEnumerable<int> items, string delimiter)
        {
            if (!items.HasItems())
                return string.Empty;

            return string.Join(delimiter, items);
        }

        public static string ToDelimitedString(this IEnumerable<string> items)
        {
            return ToDelimitedString(items, StringExtensions.DefaultDelimiter);
        }

        public static string ToDelimitedString(this IEnumerable<string> items, string delimiter)
        {
            if (!items.HasItems())
                return string.Empty;

            return string.Join(delimiter, items);
        }
    }
}
