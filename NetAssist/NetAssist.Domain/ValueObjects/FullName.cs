using NetAssist.Validation;

namespace NetAssist.Domain
{
    public class FullName : ValueObject<FullName>
    {
        public FullName(string firstName, string lastName)
        {
            Guard.Begin().IsNotNull(firstName, nameof(firstName)).IsNotNull(lastName, nameof(lastName)).Check();

            FirstName = firstName.Trim();
            LastName = lastName.Trim();
        }

        protected FullName() {}

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string Initials => string.Concat(FirstName[0], LastName[0]);

        public string Formal => string.Concat(LastName, ", ", FirstName);

        public override string ToString()
        {
            return string.Concat(FirstName, " ", LastName);
        }
    }
}
