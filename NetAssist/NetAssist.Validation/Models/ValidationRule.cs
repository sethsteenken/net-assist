namespace NetAssist.Validation
{
    public class ValidationRule
    {
        public ValidationRule(string name, string description)
        {
            Guard.Begin().IsNotNull(name, nameof(name)).Check();

            this.Name = name.Trim();
            this.Description = description.SetNullToEmpty(trim:true);
        }

        public ValidationRule(string description) : this(description?.RemoveSpecialCharacters().Trim().Replace(" ", ""), description)
        {

        }

        public string Description { get; private set; }
        public string Name { get; private set; }

        public virtual string Message => Description;

        public override string ToString()
        {
            return $"Name: {Name}. Description: {Description}.";
        }
    }
}
