using System;
using System.Collections.Generic;

namespace NetAssist.Validation
{
    [Serializable]
    public class ValidationException : Exception
    {
        public BrokenRulesList BrokenRules { get; private set; }

        public ValidationException(ValidationRule brokenRule) : this(new BrokenRulesList(new List<ValidationRule>() { brokenRule }), null)
        {

        }

        public ValidationException(BrokenRulesList brokenRules) : this (brokenRules, null)
        {
        }

        public ValidationException(BrokenRulesList brokenRules, Exception innerException) : base(brokenRules?.ToString(), innerException)
        {
            BrokenRules = brokenRules ?? new BrokenRulesList();
        }

        public virtual string FriendlyMessage
        {
            get
            {
                var message = BrokenRules?.Message;
                return string.IsNullOrWhiteSpace(message) ? base.Message : message;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}{Environment.NewLine}**Broken Rules**{Environment.NewLine}{BrokenRules}";
        }
    }
}
