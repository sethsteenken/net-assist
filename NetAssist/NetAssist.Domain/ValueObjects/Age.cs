using System;

namespace NetAssist.Domain
{
    public class Age : ValueObject<Age>
    {
        protected Age() { }

        public Age(DateTime dateOfBirth)
        {
            var now = DateTime.Now;

            if (!dateOfBirth.HasValue())
                dateOfBirth = now;

            int months = now.Month - dateOfBirth.Month;
            int years = now.Year - dateOfBirth.Year;

            if (now.Day < dateOfBirth.Day)
                months--;

            if (months < 0)
            {
                years--;
                months += 12;
            }

            Years = years < 0 ? 0 : years;
            Months = months < 0 ? 0 : months;
        }

        public Age(int years, int months)
        {
            Years = years < 0 ? 0 : years;
            Months = months < 0 ? 0 : months;
        }

        public int Years { get; private set; }
        public int Months { get; private set; }
        public int TotalMonths => (Years * 12) + Months;

        public static Age Empty => new Age();

        public override string ToString()
        {
            return string.Concat(Years, " year", Years > 1 ? "s" : "", Months > 0 ? string.Concat(", ", Months, " month", Months > 1 ? "s" : "") : "");
        }
    }
}
