namespace NetAssist
{
    public static class BoolExtensions
    {
        public static string ToSqlValueString(this bool value)
        {
            return value ? "1" : "0";
        }
    }
}
