using NetAssist.Validation;

namespace NetAssist.Domain
{
    public class GenericDataSaveResult<T> : CommandResult where T : class
    {
        public GenericDataSaveResult(bool succeeded) : this (succeeded, default(T))
        {

        }

        public GenericDataSaveResult(bool succeeded, T item) : base (succeeded)
        {
            Item = item;
        }

        public GenericDataSaveResult(bool succeeded, T item, string message) : base (succeeded, message)
        {
            Item = item;
        }

        public GenericDataSaveResult(BrokenRulesList brokenRules) : this (brokenRules, null)
        {

        }

        public GenericDataSaveResult(BrokenRulesList brokenRules, T item) : base(brokenRules)
        {
            Item = item;
        }

        public T Item { get; protected set; }
    }
}
