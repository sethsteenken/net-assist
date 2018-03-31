using System;
using System.ComponentModel;
using System.Reflection;

namespace NetAssist
{
    public static class EnumExtesnsions
    {
        public static int ToInt(this Enum enumValue)
        {
            return Convert.ToInt32(enumValue);
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
    }
}
