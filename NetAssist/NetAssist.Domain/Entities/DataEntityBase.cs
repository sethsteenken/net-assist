using System;

namespace NetAssist.Domain
{
    public abstract class DataEntityBase : Entity<int>
    {
        protected DataEntityBase() : this(Guid.NewGuid())
        {
        }

        protected DataEntityBase(int id) : base(id)
        {
        }

        protected DataEntityBase(Guid guid)
        {
            Guid = guid;
        }

        public virtual Guid Guid { get; protected set; }
        public virtual bool Archive { get; set; }
    }
}
