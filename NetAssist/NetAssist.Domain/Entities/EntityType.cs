using System;

namespace NetAssist.Domain
{
    public abstract class EntityType : LookupEntity
    {
        protected EntityType() : base() { }

        protected EntityType(Enum type, Type classType) : this (type.ToInt(), type?.ToFriendlyName(), classType)
        {

        }

        protected EntityType(int id, string name, Type classType) : base(id, name)
        {
            ClassName = classType.FullName;
        }

        public string ClassName { get; protected set; }
        public string Description { get; protected set; }
    }
}
