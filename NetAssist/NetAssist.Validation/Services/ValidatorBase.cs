using System.Collections.Generic;
using System.Linq;

namespace NetAssist.Validation
{
    public abstract class ValidatorBase<T> : IValidator<T> where T : class
    {
        protected IList<ISpecification<T>> Rules = new List<ISpecification<T>>();

        public bool IsValid(T entity)
        {
            return !BrokenRules(entity).Any();
        }

        public BrokenRulesList BrokenRules(T entity)
        {
            return new BrokenRulesList(Rules.Where(rule => !rule.IsSatisfiedBy(entity)).Select(rule => rule.Rule).ToList());
        }

        public virtual void Validate(T entity)
        {
            var brokenRules = BrokenRules(entity);
            if (brokenRules.Any())
                throw new ValidationException(brokenRules);
        }
    }
}
