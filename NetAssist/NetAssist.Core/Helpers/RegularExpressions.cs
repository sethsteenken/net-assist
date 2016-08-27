namespace NetAssist
{
    public static class RegularExpressions
    {
        public const string SpecialCharacters = "(?:[^a-z0-9 -]|(?<=['\"])s)";
        public const string Email = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        public const string Phone = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";
        public const string Zip = @"\d{5}-?(\d{4})?$";
        public const string SSN = @"^\d{9}|\d{3}-\d{2}-\d{4}$";
    }
}
