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

        public Guid Guid { get; private set; }
        public bool Archive { get; set; }

        [SerializeIgnore]
        protected abstract int EntityTypeId { get; }

        [SerializeIgnore]
        public virtual bool LogHistory => true;

        public void VerifyGuid()
        {
            if (Guid == Guid.Empty)
                Guid = Guid.NewGuid();
        }
    }
}
