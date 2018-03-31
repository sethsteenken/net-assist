using System.Reflection;

namespace NetAssist
{
    public static class PropertyInfoExtensions
    {
        public static bool IsCollection(this PropertyInfo property)
        {
            return property.PropertyType.IsCollection();
        }
    }
}
