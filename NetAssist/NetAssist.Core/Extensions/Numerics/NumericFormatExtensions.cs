namespace NetAssist
{
    public static class NumericFormatExtensions
    {
        public static string Format(this decimal? value)
        {
            return value.Format(false);
        }

        public static string Format(this decimal? value, bool includeDecimalPlaces)
        {
            if (value == null)
                return "0";

            return ((decimal)value).Format(includeDecimalPlaces);
        }

        public static string Format(this decimal value)
        {
            return value.Format(false);
        }

        public static string Format(this decimal value, bool includeDecimalPlaces)
        {
            var s = string.Format("{0:0.00}", value);
            if (s.EndsWith("00") && !includeDecimalPlaces)
                return ((int)value).ToString();
            else
                return s;
        }
    }
}
