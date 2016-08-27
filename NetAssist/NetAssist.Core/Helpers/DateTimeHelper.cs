using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace NetAssist
{
    public static class DateTimeHelper
    {
        private static readonly Dictionary<int, string> _months = new Dictionary<int, string>()
        {
            { 1, "January" },
            { 2, "February" },
            { 3, "March" },
            { 4, "April" },
            { 5, "May" },
            { 6, "June" },
            { 7, "July" },
            { 8, "August" },
            { 9, "September" },
            { 10, "October" },
            { 11, "November" },
            { 12, "December" }
        };

        public static string GetMonthName(int month)
        {
            string name = "";
            if (!_months.TryGetValue(month, out name))
                throw new ArgumentException($"Month value '{month}' not a valid month.");
            return name;
        }

        public static string[] GetMonths()
        {
            return DateTimeFormatInfo.InvariantInfo.MonthNames.Take(12).ToArray();
        }

        public static int[] GetDaysInAMonth()
        {
            var months = new int[31];
            for (var i = 0; i < 31; i++)
            {
                months[i] = i + 1;
            }
            return months;
        }

        public static int GetNumberOfMonths(DateTime startDate, DateTime endDate)
        {
            return ((endDate.Year - startDate.Year) * 12) + endDate.Month - startDate.Month + 1;
        }
    }
}
