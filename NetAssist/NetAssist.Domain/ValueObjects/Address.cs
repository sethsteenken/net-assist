namespace NetAssist.Domain
{
    public class Address : ValueObject<Address>
    {
        protected Address() { }

        public Address(string street, string city, string state, string zip) : this (street, null, city, state, zip)
        {

        }

        public Address(string street, string streetTwo, string city, string state, string zip) : this (street, streetTwo, city, state, zip, "United States")
        {

        }

        public Address(string street, string streetTwo, string city, string state, string zip, string country)
        {
            Street = street.SetEmptyToNull();
            StreetTwo = streetTwo.SetEmptyToNull();
            City = city.SetEmptyToNull();
            State = state.SetEmptyToNull();
            Zip = zip.SetEmptyToNull();
            Country = country.SetEmptyToNull();
        }

        public string Street { get; private set; }
        public string StreetTwo { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Zip { get; private set; }
        public string Country { get; private set; }

        public static Address Empty => new Address();
    }
}
