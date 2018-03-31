using NetAssist.Validation;

namespace NetAssist.Domain
{
    public class EntityHistoryData : Entity<int>, IEntityHistoryData
    {
        protected EntityHistoryData() { }

        public EntityHistoryData(EntityHistory history, string data)
        {
            Guard.Begin().IsNotNull(history, nameof(history)).Check();
            Value = data.SetEmptyToNull();
            History = history;
        }

        public string Value { get; private set; }
        public virtual EntityHistory History { get; private set; }
    }
}
