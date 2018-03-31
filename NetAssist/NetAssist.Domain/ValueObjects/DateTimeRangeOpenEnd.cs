using NetAssist.Validation;
using System;

namespace NetAssist.Domain
{
    public class DateTimeRangeOpenEnd : ValueObject<DateTimeRangeOpenEnd>
    {
        protected DateTimeRangeOpenEnd() { }

        public DateTimeRangeOpenEnd(DateTime startDate) : this (startDate, null)
        { }

        public DateTimeRangeOpenEnd(DateTime startDate, DateTime? endDate)
        {
            if (endDate != null)
                Guard.Begin().IsValidDateRange(startDate, (DateTime)endDate).Check();

            StartDate = startDate;
            EndDate = endDate.HasValue() ? endDate : null;
        }

        public DateTimeRangeOpenEnd(DateTime startDate, TimeSpan span) 
            : this (startDate, startDate.Add(span))
        {
        }

        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }

        public override string ToString()
        {
            return ToString(null);
        }

        public string ToString(string format)
        {
            if (string.IsNullOrWhiteSpace(format))
                format = DateTimeFormats.ShortDateFullYear;

            if (EndDate.HasValue())
                return $"{StartDate.Format(format)} - {EndDate.Format(format)}";
            else
                return StartDate.Format(format);
        }

        public DateTimeRangeOpenEnd ToUTC() => new DateTimeRangeOpenEnd(StartDate.ToUniversalTime(), EndDate?.ToUniversalTime());

        // determine if StartDate is before current date and EndDate is greater than current date (if provided)
        public virtual bool IsCurrent => StartDate.Date <= DateTime.Now.Date && (EndDate == null || EndDate.Value.Date >= DateTime.Now.Date);
    }
}
