using System.Linq;

namespace NetAssist.Domain.Services
{
    public class EntityHistoryStore : IEntityHistoryStore
    {
        private readonly ICommandRepository<IEntityHistory, int> _repository;
        private readonly ISerializer _serializer;
        private readonly IUserId _currentUser;

        public EntityHistoryStore(ICommandRepository<IEntityHistory, int> repository, ISerializer serializer, IUserId currentUser)
        {
            _repository = repository;
            _serializer = serializer;
            _currentUser = currentUser;
        }

        public virtual void ProcessCommand(IEntityGuid entity, CommandTypeOption type)
        {
            if (entity == null)
                return;

            var storeHistoryAttributes = entity.GetType().GetCustomAttributes(typeof(StoreHistoryAttribute), inherit: true);
            if (!storeHistoryAttributes.HasItems<object>())
                return;

            var storeHistoryAttr = (StoreHistoryAttribute)storeHistoryAttributes.First();
            string serializedData = null;
            if (storeHistoryAttr.StoreSnapShot)
                serializedData = _serializer.Serialize(entity);

            var entityHistory = CreateHistoryRecord(storeHistoryAttr, entity, type, _currentUser, serializedData);

            ProcessCustomValuesForEntity(entity, entityHistory);

            _repository.AddOrUpdate(entityHistory);
        }

        protected virtual IEntityHistory CreateHistoryRecord(StoreHistoryAttribute attribute, IEntityGuid entity, CommandTypeOption type, IUserId user, string data)
        {
            return new EntityHistory(attribute.EntityTypeId, type, entity.Guid, user.Id, data);
        }

        protected virtual void ProcessCustomValuesForEntity(object entity, IEntityHistory entityHistory)
        {
            if (entity == null || entityHistory == null)
                return;

            if (typeof(IEntityHistoryUpdated).IsAssignableFrom(entity.GetType()))
                (entity as IEntityHistoryUpdated).OnHistoryUpdate(entityHistory);
        }
    }

    public class EntityHistoryStoreNotApplicable : IEntityHistoryStore
    {
        public void ProcessCommand(IEntityGuid entity, CommandTypeOption type)
        {
            return;
        }
    }
}
