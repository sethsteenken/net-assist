namespace NetAssist.Validation
{
    public interface ISpecification<T> where T : class
    {
        ValidationRule Rule { get; }
        bool IsSatisfiedBy(T subject);
    }
}
