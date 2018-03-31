using System;
using System.Collections.Generic;
using System.Linq;

namespace NetAssist
{
    public static class NumericExtensions
    {
        public static int? CleanNullable(this int? value)
        {
            return CleanNullable(value, true);
        }

        public static int? CleanNullable(this int? value, bool positiveOnly)
        {
            if (value == null || value == 0 || (value < 0 && positiveOnly))
                return null;
            else
                return value;
        }

        public static decimal? CleanNullable(this decimal? value)
        {
            return CleanNullable(value, true);
        }

        public static decimal? CleanNullable(this decimal? value, bool positiveOnly)
        {
            if (value == null || value == 0 || (value < 0 && positiveOnly))
                return null;
            else
                return value;
        }

        public static double? CleanNullable(this double? value)
        {
            return CleanNullable(value, true);
        }

        public static double? CleanNullable(this double? value, bool positiveOnly)
        {
            if (value == null || value == 0 || (value < 0 && positiveOnly))
                return null;
            else
                return value;
        }

        public static long? CleanNullable(this long? value)
        {
            return CleanNullable(value, true);
        }

        public static long? CleanNullable(this long? value, bool positiveOnly)
        {
            if (value == null || value == 0 || (value < 0 && positiveOnly))
                return null;
            else
                return value;
        }

        public static string ToOccurrenceSuffix(this int integer)
        {
            switch (integer % 100)
            {
                case 11:
                case 12:
                case 13:
                    return "th";
            }
            switch (integer % 10)
            {
                case 1:
                    return "st";
                case 2:
                    return "nd";
                case 3:
                    return "rd";
                default:
                    return "th";
            }
        }

        public static List<Tuple<int, int>> ToPairsList(this IEnumerable<int> list)
        {
            if (list == null)
                return null;

            // Ref - http://stackoverflow.com/a/7242116 
            // get list of all pair combinations from list of ints
            return (from item1 in list
                    from item2 in list
                    where item1 < item2
                    select Tuple.Create(item1, item2))
                    .ToList();
        }

        public static int DivideBy(this int value, int divideBy, bool roundUp = true)
        {
            int quotient = Math.DivRem(value, divideBy, out int remainder);
            return remainder == 0 || !roundUp ? quotient : quotient + 1;
        }
    }
}
