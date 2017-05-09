using System;

namespace NetAssist.Domain
{
    public static class DateTimeExtensions
    {
        public static Age ToAge(this DateTime dateOfBirth)
        {
            return new Age(dateOfBirth);
        }
    }
}
