using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NetAssist
{
    public static class GenericTypesHelper
    {
        public static List<KeyValuePair<Type, Type>> GetTypesWithContracts(Assembly assembly)
        {
            return GetTypesWithContracts(assembly, null);
        }

        public static List<KeyValuePair<Type, Type>> GetTypesWithContracts(Assembly assembly, string nameSpace)
        {
            nameSpace = nameSpace.SetEmptyToNull(trim: true);

            //get all public types that have associated interfaces and are not abstract in supplied assembly
            var registrations = from type in assembly.GetExportedTypes()
                                where (nameSpace == null || type.Namespace == nameSpace)
                                   && type.GetInterfaces().Where(t => !t.IsConstructedGenericType).Any()
                                   && !type.IsAbstract
                                select new { Service = type.GetInterfaces().Where(t => !t.IsConstructedGenericType).Single(), Implementation = type };

            //return list of key-value pars of interfaces and associated implmemntation
            var types = new List<KeyValuePair<Type, Type>>();
            if (registrations.Any())
            {
                foreach (var item in registrations)
                {
                    types.Add(new KeyValuePair<Type, Type>(item.Service, item.Implementation));
                }
            }

            return types;
        }

        public static void ConstructDefaultIfNull<T>(ref T item) where T : class
        {
            ConstructDefaultIfNull(ref item, null);
        }

        public static void ConstructDefaultIfNull<T>(ref T item, string overridableMethodName) where T : class
        {
            if (item == null)
            {
                if (typeof(T).HasDefaultConstructor())
                    item = Activator.CreateInstance<T>();
                else
                {
                    var message = $"Cannot create instance of type {typeof(T).FullName} because it does not have a default constructor.";
                    if (!string.IsNullOrWhiteSpace(overridableMethodName))
                        message = string.Concat(message, $" Override the method \"{overridableMethodName}\" in order to create a valid default instance.");
                    throw new InvalidOperationException(message);
                }
            }
        }
    }
}
