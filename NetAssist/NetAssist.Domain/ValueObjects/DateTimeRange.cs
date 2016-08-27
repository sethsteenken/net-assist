using NetAssist.Validation;
using System;

namespace NetAssist.Domain
{
    public class DateTimeRange : ValueObject<DateTimeRange>
    {
        public DateTimeRange(DateTime startDate, DateTime endDate)
        {
            Guard.Begin().IsValidDateRange(startDate, endDate).Check();

            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTimeRange(DateTime startDate, TimeSpan span) 
            : this (startDate, startDate.Add(span))
        {
        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
    }
}
