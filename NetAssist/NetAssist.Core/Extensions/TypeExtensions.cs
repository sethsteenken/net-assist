using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NetAssist
{
    public static class TypeExtensions
    {
        public static bool HasDefaultConstructor(this Type type)
        {
            return type?.GetConstructor(Type.EmptyTypes) != null;
        }

        public static bool IsCollection(this Type type)
        {
            return (from interfaceType in type.GetInterfaces()
                    where interfaceType.IsGenericType
                    let baseInterface = interfaceType.GetGenericTypeDefinition()
                    where (baseInterface == typeof(IEnumerable<>)) || (baseInterface == typeof(IEnumerable))
                    select interfaceType).Any()
                    ||
                    typeof(IEnumerable).IsAssignableFrom(type) || typeof(IEnumerable<>).IsAssignableFrom(type)
                    ||
                    type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>);
        }
    }
}
