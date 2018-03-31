using System;

namespace NetAssist.Domain
{
    public class EntityHistory : Entity<int>, IEntityHistory
    {
        protected EntityHistory() { }

        public EntityHistory(int entityTypeId, CommandTypeOption commandType, Guid entityGuid, int userId)
            : this(entityTypeId, commandType, entityGuid, userId, null)
        {

        }

        public EntityHistory(int entityTypeId, CommandTypeOption commandType, Guid entityGuid, int userId, string data)
        {
            TypeId = entityTypeId;
            CommandTypeId = (int)commandType;
            EntityGuid = entityGuid;
            Event = new CommandDate(userId);

            if (!string.IsNullOrWhiteSpace(data))
                Data = new EntityHistoryData(this, data);
        }

        public Guid EntityGuid { get; private set; }
        public int TypeId { get; private set; }

        public int CommandTypeId { get; private set; }
        public CommandTypeOption CommandType => (CommandTypeOption)CommandTypeId;
        public CommandDate Event { get; private set; }

        public virtual EntityHistoryData Data { get; private set; }
    }
}
