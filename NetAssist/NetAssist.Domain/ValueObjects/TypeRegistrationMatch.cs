using System;
using System.Linq;

namespace NetAssist.Domain
{
    public class TypeRegistrationMatch : ValueObject<TypeRegistrationMatch>
    {
        public TypeRegistrationMatch(Type type) : this (type.GetTopLevelInterfaces().Single(), type)
        {

        }

        public TypeRegistrationMatch(Type declaration, Type implementation)
        {
            Declaration = declaration;
            Implementation = implementation;
        }

        public Type Declaration { get; private set; }
        public Type Implementation { get; private set; }
    }
}
