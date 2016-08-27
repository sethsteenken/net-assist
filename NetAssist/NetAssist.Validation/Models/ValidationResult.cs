using System.Collections.Generic;
using System.Linq;

namespace NetAssist.Validation
{
    public class ValidationResult
    {
        public ValidationResult(bool succeeded)
        {
            Succeeded = succeeded;
        }

        public ValidationResult(ValidationRule rule) : this(new BrokenRulesList(new List<ValidationRule>() { rule }))
        {

        }

        public ValidationResult(BrokenRulesList brokenRules)
        {
            BrokenRules = (brokenRules ?? new BrokenRulesList());
            Succeeded = !brokenRules.Any();
        }

        public bool Succeeded { get; private set; }
        public BrokenRulesList BrokenRules { get; private set; }

        public static ValidationResult Fail(ValidationRule rule) => new ValidationResult(rule);
        public static ValidationResult Fail(BrokenRulesList brokenRules) => new ValidationResult(brokenRules);
        public static ValidationResult Success() => new ValidationResult(true);
    }
}
