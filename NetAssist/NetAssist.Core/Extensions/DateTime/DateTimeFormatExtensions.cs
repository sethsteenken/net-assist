using System;

namespace NetAssist
{
    public static class DateTimeFormatExtensions
    {
        public const string DefaultFormat = "MM/dd/yyyy";

        public static string Format(this DateTime? date)
        {
            return date.Format(DefaultFormat);
        }

        public static string Format(this DateTime? date, string format)
        {
            return Format(date, format, useExtendedSpecifiers: false);
        }

        public static string Format(this DateTime? date, string format, bool useExtendedSpecifiers)
        {
            if (!date.HasValue())
                return string.Empty;
            else
                return ((DateTime)date).Format(format, useExtendedSpecifiers);
        }

        public static string Format(this DateTime date)
        {
            return date.Format(DefaultFormat);
        }

        public static string Format(this DateTime date, string format)
        {
            return Format(date, format, useExtendedSpecifiers: false);
        }

        public static string Format(this DateTime date, string format, bool useExtendedSpecifiers)
        {
            var formattedDate = date.ToString(format);

            if (useExtendedSpecifiers)
            {
                return formattedDate
                    .Replace("nn", date.Day.ToOccurrenceSuffix().ToLower())
                    .Replace("NN", date.Day.ToOccurrenceSuffix().ToUpper());
            }
            else
                return formattedDate;
        }
    }
}
