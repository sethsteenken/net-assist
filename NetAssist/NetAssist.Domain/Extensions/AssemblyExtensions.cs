using NetAssist.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NetAssist.Domain
{
    public static class AssemblyExtensions
    {
        public static IReadOnlyList<TypeRegistrationMatch> GetTypeMatches(this Assembly assembly)
        {
            return GetTypeMatches(assembly, null);
        }

        public static IReadOnlyList<TypeRegistrationMatch> GetTypeMatches(this Assembly assembly, Func<Type, bool> query)
        {
            Guard.Begin().IsNotNull(assembly, nameof(assembly)).Check();

            var registrations =
                from type in assembly.GetExportedTypes()
                where type.GetTopLevelInterfaces().Count() == 1
                    && !type.IsAbstract
                select type;

            if (query != null)
                registrations = registrations.Where(query);

            return registrations.Select(type => new TypeRegistrationMatch(type)).ToList();
        }
    }
}
