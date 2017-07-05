using System;

namespace NetAssist.Domain
{
    public class EntityHistoryDates : ValueObject<EntityHistoryDates>
    {
        protected EntityHistoryDates() { }
        public EntityHistoryDates(DateTime createdDate, DateTime lastUpdatedDate)
        {
            CreatedDate = createdDate;
            LastUpdatedDate = lastUpdatedDate;
        }

        public DateTime CreatedDate { get; private set; }
        public DateTime LastUpdatedDate { get; private set; }
    }
}
