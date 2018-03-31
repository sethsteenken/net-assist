using System;

namespace NetAssist
{
    public static class DateTimeExtensions
    {
        public static bool HasValue(this DateTime? date)
        {
            if (date == null)
                return false;
            else
                return ((DateTime)date).HasValue();
        }

        public static bool HasValue(this DateTime date)
        {
            return !(date == DateTime.MinValue);
        }

        public static DateTime ToFirstDateOfMonth(this DateTime date)
        {
            return DateTime.Parse(string.Format("{0}/1/{1}", date.Month, date.Year));
        }

        public static DateTime ToLastDateOfMonth(this DateTime date)
        {
            var lastDayInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            return DateTime.Parse(string.Format("{0}/{1}/{2}", date.Month, lastDayInMonth, date.Year));
        }

        public static DateTime ToFirstDateOfWeek(this DateTime date)
        {
            int dayIndex = 0;
            int dayOfMonth = date.Day; //grab the current date's day of month

            //current weekday index; to help calculate number between days
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    dayIndex = 0;
                    break;
                case DayOfWeek.Tuesday:
                    dayIndex = 1;
                    break;
                case DayOfWeek.Wednesday:
                    dayIndex = 2;
                    break;
                case DayOfWeek.Thursday:
                    dayIndex = 3;
                    break;
                case DayOfWeek.Friday:
                    dayIndex = 4;
                    break;
                case DayOfWeek.Saturday:
                    dayIndex = 5;
                    break;
                case DayOfWeek.Sunday:
                    dayIndex = 6;
                    break;
            }

            //default year and month values to the current
            int year = date.Year;
            int month = date.Month;
            int newDayOfMonth = 0;

            //check to see if the current weekday index is over the day of month (the week is split across 2 months)
            if (dayIndex >= dayOfMonth)
            {
                //it's janurary (the week also splits across 2 years)
                if (date.Month == 1)
                {
                    month = 12; //previous month is dec
                    year--; //decrement the year
                }
                else
                    month--; //just decrement the month to the previous month of the current year

                var numOfDaysInMonth = DateTime.DaysInMonth(year, month); //get the number of days in the month
                newDayOfMonth = numOfDaysInMonth - (dayIndex - dayOfMonth); //calculate the date needed by counting back from current date and then previous month's end date
            }
            else
                newDayOfMonth = dayOfMonth - dayIndex; //simply grab the difference to get Monday's date (which is within the current month)

            return new DateTime(year, month, newDayOfMonth); ;
        }

        public static DateTime ToFirstMondayOfMonth(this DateTime date)
        {
            var monday = new DateTime(date.Year, date.Month, 1);
            if (monday.DayOfWeek != DayOfWeek.Monday)
            {
                do { monday = monday.AddDays(1); }
                while (monday.DayOfWeek != DayOfWeek.Monday);
            }

            return monday;
        }

        public static DateTime ToFirstMondayOfYear(this DateTime date, int? year = null)
        {
            int day = 0;
            if (year == null)
                year = date.Year;

            while ((new DateTime((int)year, 01, ++day)).DayOfWeek != DayOfWeek.Monday) ;
            return new DateTime((int)year, 01, day);
        }

        public static int ToYearsOld(this DateTime dateOfBirth)
        {
            if (!dateOfBirth.HasValue())
                return 0;

            int age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }

        public static bool IsMidnight(this DateTime? date)
        {
            if (!date.HasValue())
                return false;
            return IsMidnight((DateTime)date);
        }

        public static bool IsMidnight(this DateTime date)
        {
            if (!date.HasValue())
                return false;
            return date.TimeOfDay == TimeSpan.Zero;
        }
    }
}
