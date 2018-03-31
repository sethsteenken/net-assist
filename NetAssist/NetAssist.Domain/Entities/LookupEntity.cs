using System;

namespace NetAssist.Domain
{
    public abstract class LookupEntity : Entity<int>, ILookupEntity
    {
        protected LookupEntity() { }

        protected LookupEntity(Enum value) : this(value.ToInt(), value?.ToFriendlyName()) { }

        protected LookupEntity(int id, string name) : base(id)
        {
            Name = name?.Trim();
        }

        public string Name { get; protected set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
