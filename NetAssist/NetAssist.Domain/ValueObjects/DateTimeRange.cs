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

        // determine if StartDate is before current date and EndDate is greater than current date
        public virtual bool IsCurrent => StartDate.Date <= DateTime.Now.Date && EndDate.Date >= DateTime.Now.Date;

        public override string ToString()
        {
            return ToString(null);
        }

        public string ToString(string format)
        {
            if (string.IsNullOrWhiteSpace(format))
                format = DateTimeFormats.ShortDateFullYear;

            return $"{StartDate.Format(format)} - {EndDate.Format(format)}";
        }

        public DateTimeRange ToUTC() => new DateTimeRange(StartDate.ToUniversalTime(), EndDate.ToUniversalTime());
    }
}
