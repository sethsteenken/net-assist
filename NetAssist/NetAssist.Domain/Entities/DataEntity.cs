using System;

namespace NetAssist.Domain
{
    public abstract class DataEntity : Entity<int>, IDataEntity
    {
        protected DataEntity() : this(Guid.NewGuid())
        {
        }

        protected DataEntity(int id) : base(id)
        {
        }

        protected DataEntity(Guid guid)
        {
            Guid = guid;
        }

        public virtual Guid Guid { get; protected set; }
        public virtual bool Archive { get; set; }
    }
}
