using System;

namespace NetAssist.Domain
{
    public abstract class EntityTypeBase : LookupEntity
    {
        protected EntityTypeBase() : base() { }

        protected EntityTypeBase(Enum type, Type classType) : this (type.ToInt(), type?.ToFriendlyName(), classType)
        {

        }

        protected EntityTypeBase(int id, string name, Type classType) : base(id, name)
        {
            ClassName = classType.FullName;
        }

        public string ClassName { get; protected set; }
        public string Description { get; protected set; }
    }
}
