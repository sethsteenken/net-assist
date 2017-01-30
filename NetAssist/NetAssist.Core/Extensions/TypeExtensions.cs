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
                    (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>));
        }

        /// <summary>
        /// Determine whether a type is simple (String, Decimal, DateTime, etc) 
        /// or complex (i.e. custom class with public properties and methods).
        /// </summary>
        /// <see cref="http://stackoverflow.com/questions/2442534/how-to-test-if-type-is-primitive"/>
        public static bool IsSimpleType(this Type type)
        {
            return type.IsValueType ||
                type.IsPrimitive ||
                new Type[] {
                    typeof(String),
                    typeof(Decimal),
                    typeof(DateTime),
                    typeof(DateTimeOffset),
                    typeof(TimeSpan),
                    typeof(Guid)
                }.Contains(type) ||
                Convert.GetTypeCode(type) != TypeCode.Object;
        }

        public static IEnumerable<Type> GetTopLevelInterfaces(this Type type)
        {
            if (type == null)
                return null;

            var allInterfaces = type.GetInterfaces();
            var interfaces = allInterfaces
                .Where(x => !allInterfaces.Any(y => y.GetInterfaces().Contains(x)));

            if (type.BaseType != null)
                interfaces = interfaces.Except(type.BaseType.GetInterfaces());

            return interfaces;
        }
    }
}
