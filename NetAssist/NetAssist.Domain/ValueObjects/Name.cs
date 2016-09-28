namespace NetAssist.Domain
{
    public class Name : ValueObject<Name>
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName.SetEmptyToNull();
            LastName = lastName.SetEmptyToNull();
        }

        protected Name() { }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public virtual string Initials => string.Concat(FirstName?[0], LastName?[0]);

        public virtual string ToFormalString()
        {
            if (string.IsNullOrWhiteSpace(FirstName))
                return LastName ?? string.Empty;
            else if (string.IsNullOrWhiteSpace(LastName))
                return FirstName ?? string.Empty;
            else
                return string.Concat(LastName, ", ", FirstName);
        }
        
        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(FirstName))
                return LastName ?? string.Empty;
            else if (string.IsNullOrWhiteSpace(LastName))
                return FirstName ?? string.Empty;
            else
                return string.Concat(FirstName, " ", LastName);
        }
    }
}
