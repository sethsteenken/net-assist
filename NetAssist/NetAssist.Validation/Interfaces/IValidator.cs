namespace NetAssist.Validation
{
    public interface IValidator<T> where T : class
    {
        bool IsValid(T entity);
        BrokenRulesList BrokenRules(T entity);
        void Validate(T entity);
    }
}
