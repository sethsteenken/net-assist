namespace NetAssist.Domain
{
    public class EntityHistoryDates : ValueObject<EntityHistoryDates>
    {
        protected EntityHistoryDates() { }
        public EntityHistoryDates(CommandDate createdDate, CommandDate lastUpdatedDate)
        {
            CreatedDate = createdDate ?? CommandDate.Empty;
            LastUpdatedDate = lastUpdatedDate ?? CommandDate.Empty;
        }

        public CommandDate CreatedDate { get; private set; }
        public CommandDate LastUpdatedDate { get; private set; }
    }
}
