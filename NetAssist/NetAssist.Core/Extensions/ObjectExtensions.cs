using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NetAssist
{
    public static class ObjectExtensions
    {
        public static bool HasProperty(this object obj, string propertyName)
        {
            return Property(obj, propertyName) != null;
        }

        public static PropertyInfo Property(this object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName);
        }

        public static IEnumerable<PropertyInfo> CollectionProperties(this Type type)
        {
            // Reference - http://stackoverflow.com/questions/24598122/getting-all-icollection-properties-through-reflection

            var properties = type.GetProperties();

            // Get properties with PropertyType declared as interface
            var interfaceProps =
                from prop in properties
                from interfaceType in prop.PropertyType.GetInterfaces()
                where interfaceType.IsGenericType
                let baseInterface = interfaceType.GetGenericTypeDefinition()
                where (baseInterface == typeof(ICollection<>)) || (baseInterface == typeof(ICollection))
                select prop;

            // Get properties with PropertyType declared(probably) as solid types.
            var nonInterfaceProps =
                from prop in properties
                where typeof(ICollection).IsAssignableFrom(prop.PropertyType) || typeof(ICollection<>).IsAssignableFrom(prop.PropertyType)
                select prop;

            // get generic type collections
            var genericTypes =
                from prop in properties
                where prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>)
                select prop;

            // Combine  queries into one resulting
            return interfaceProps.Union(nonInterfaceProps).Union(genericTypes);
        }

        public static bool IsEnumerable(this object obj)
        {
            if (obj == null)
                return false;

            return obj.GetType().IsGenericType && obj is IEnumerable;
        }
    }
}
