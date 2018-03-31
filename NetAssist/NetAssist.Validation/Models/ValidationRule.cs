namespace NetAssist.Validation
{
    public class ValidationRule
    {
        public ValidationRule(string description)
        {
            Description = description.SetEmptyToNull();
        }

        public string Description { get; private set; }

        public virtual string Message => Description;

        public override string ToString()
        {
            return Description;
        }
    }
}
