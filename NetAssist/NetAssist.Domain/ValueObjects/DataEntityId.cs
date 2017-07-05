using System;

namespace NetAssist.Domain
{
    public class DataEntityId : ValueObject<DataEntityId>
    {
        protected DataEntityId() { }

        public DataEntityId(int id, Guid guid)
        {
            Id = id;
            Guid = guid;
        }

        public int Id { get; private set; }
        public Guid Guid { get; private set; }

        public override string ToString()
        {
            return $"(Id: {Id} Guid: {Guid})";
        }
    }
}
