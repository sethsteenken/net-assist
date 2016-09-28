using System;

namespace NetAssist.Domain
{
    public abstract class DataEntity : Entity<int>
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

        [SerializeIgnore]
        public abstract EntityType EntityType { get; }

        [SerializeIgnore]
        public virtual bool LogHistory => true;

        public void VerifyGuid()
        {
            if (Guid == Guid.Empty)
                Guid = Guid.NewGuid();
        }
    }
}
