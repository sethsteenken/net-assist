using System;

namespace NetAssist.Domain
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class StoreHistoryAttribute : SerializeAttribute
    {
        public StoreHistoryAttribute(int entityTypeId) : this(entityTypeId, true)
        {

        }

        public StoreHistoryAttribute(int entityTypeId, bool storeSnapShot)
        {
            EntityTypeId = entityTypeId;
            StoreSnapShot = storeSnapShot;
        }

        public int EntityTypeId { get; set; }

        public bool StoreSnapShot { get; set; } = true;
    }
}
