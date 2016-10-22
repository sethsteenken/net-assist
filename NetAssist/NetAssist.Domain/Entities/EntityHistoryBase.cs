using System;

namespace NetAssist.Domain
{
    public abstract class EntityHistoryBase : Entity<int>
    {
        protected EntityHistoryBase() { }

        public EntityHistoryBase(int typeId, CommandTypeOption commandType, Guid entityId, string data, int user)
        {
            TypeId = typeId;
            CommandTypeId = (int)commandType;
            EntityId = entityId;
            SerializedData = data.SetEmptyToNull();
            Created = new CommandDate(user);
        }

        public Guid EntityId { get; private set; }
        public int TypeId { get; private set; }
        public virtual EntityTypeBase Type { get; private set; }


        public int CommandTypeId { get; private set; }
        public CommandTypeOption CommandType => (CommandTypeOption)CommandTypeId;

        public string SerializedData { get; private set; }
        public CommandDate Created { get; private set; }
    }

    public abstract class EntityHistoryBase<T> : Entity<T>
    {
        protected EntityHistoryBase() { }

        public EntityHistoryBase(T typeId, CommandTypeOption commandType, Guid entityId, string data, T userId)
        {
            TypeId = typeId;
            CommandTypeId = (int)commandType;
            EntityId = entityId;
            SerializedData = data.SetEmptyToNull();
            Created = new CommandDate<T>(userId);
        }

        public Guid EntityId { get; private set; }
        public T TypeId { get; private set; }
        public virtual EntityTypeBase Type { get; private set; }


        public int CommandTypeId { get; private set; }
        public CommandTypeOption CommandType => (CommandTypeOption)CommandTypeId;

        public string SerializedData { get; private set; }
        public CommandDate<T> Created { get; private set; }
    }
}
