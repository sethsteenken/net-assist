using System;
using System.Text;

namespace NetAssist
{
    public static class TimeSpanExtensions
    {
        public static string ToDurationString(this TimeSpan? value)
        {
            if (value == null)
                return string.Empty;

            var span = (TimeSpan)value;
            var sb = new StringBuilder();

            if (span.Days > 0)
                sb.Append(string.Format("{0} {1}, ", span.Days, span.Days > 1 ? "days" : "day"));

            if (span.Hours > 0)
                sb.Append(string.Format("{0} {1}, ", span.Hours, span.Hours > 1 ? "hrs" : "hr"));

            if (span.Minutes > 0)
                sb.Append(string.Format("{0} {1}, ", span.Minutes, span.Minutes > 1 ? "mins" : "min"));

            if (sb.Length > 0)
                sb.Remove(sb.ToString().LastIndexOf(","), 1);

            return sb.ToString();
        }
    }
}
