using NetAssist.Validation;

namespace NetAssist.Domain
{
    public class EntitySaveResult<T, TKey> : CommandResult where T : Entity<TKey>
    {
        public EntitySaveResult(bool succeeded) : this (succeeded, default(T))
        {

        }

        public EntitySaveResult(bool succeeded, T entity) : base (succeeded)
        {
            Entity = entity;
        }

        public EntitySaveResult(bool succeeded, T entity, string message) : base (succeeded, message)
        {
            Entity = entity;
        }

        public EntitySaveResult(BrokenRulesList brokenRules) : base (brokenRules)
        {

        }

        public T Entity { get; protected set; }
    }
}
