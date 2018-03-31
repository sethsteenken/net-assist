using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetAssist.Validation
{
    public class BrokenRulesList : List<ValidationRule>
    {
        public BrokenRulesList()
        {

        }

        public static readonly BrokenRulesList Empty = new BrokenRulesList();

        public BrokenRulesList(IEnumerable<ValidationRule> list) : base(list)
        {

        }

        public BrokenRulesList(ValidationRule rule) : base(new List<ValidationRule>() { rule })
        {

        }

        public string Message => FormattedResults(detailed: false);

        public void AddUnique(ValidationRule rule, bool checkSelf = true)
        {
            if (rule == null)
                return;

            if (checkSelf && !this.HasItems())
            {
                Add(rule);
                return;
            }

            if (!this.Any(x => x.Description == rule.Description))
                Add(rule);
        }

        public void AddUniqueRange(IEnumerable<ValidationRule> list)
        {
            if (!list.HasItems())
                return;

            if (!this.HasItems())
            {
                AddRange(list);
                return;
            }

            foreach (var item in list)
            {
                AddUnique(item, checkSelf: false);
            }
        }

        public override string ToString()
        {
            return FormattedResults(detailed: true);
        }

        private string FormattedResults(bool detailed)
        {
            if (this == null || Count == 0)
                return string.Empty;

            if (this.Count == 1)
                return GetRuleMessage(this[0], detailed);

            var sb = new StringBuilder();
            foreach (var item in this)
            {
                sb.AppendLine(GetRuleMessage(item, detailed));
            }
            return sb.ToString();
        }

        public IEnumerable<string> ToMessages()
        {
            return this.Select(x => x.Message).ToList();
        }

        private static string GetRuleMessage(ValidationRule rule, bool detailed)
        {
            if (detailed)
                return rule.ToString();
            else
                return rule.Message;
        }

        public const string ModelStateKey = "BrokenRules";
    }
}
