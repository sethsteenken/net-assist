using System;

namespace NetAssist.Domain
{
    public abstract class EntityHistory<T> : Entity<T>
    {
        protected EntityHistory() { }

        public EntityHistory(T typeId, CommandTypeOption commandType, Guid entityId, string data, T userId)
        {
            TypeId = typeId;
            CommandTypeId = (int)commandType;
            EntityId = entityId;
            SerializedData = data.SetEmptyToNull();
            Created = new CommandDate<T>(userId);
        }

        public Guid EntityId { get; private set; }
        public T TypeId { get; private set; }
        public virtual EntityType Type { get; private set; }


        public int CommandTypeId { get; private set; }
        public CommandTypeOption CommandType => (CommandTypeOption)CommandTypeId;

        public string SerializedData { get; private set; }
        public CommandDate<T> Created { get; private set; }
    }
}
