using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetAssist.Validation
{
    public static class ValidationGuardExtensions
    {
        private const string _exceptionMessage = "Validation/Guard errors occurred. See inner exception(s) for details.";

        public static ValidationGuard Check(this ValidationGuard validation)
        {
            if (validation == null)
                return validation;
            else if (validation.Exceptions.Any())
            {
                if (validation.Exceptions.Take(2).Count() == 1)
                    throw new ValidationGuardException(_exceptionMessage, validation.Exceptions.First());
                else
                    throw new ValidationGuardException(_exceptionMessage, new MultiException(validation.Exceptions));
            }
            else
                return validation;
        }

        #region Validate Null and Defaults
        public static ValidationGuard IsNotNull<T>(this ValidationGuard validation, T value, string paramName) where T : class
        {
            if (value == null || (value is string && string.IsNullOrWhiteSpace(value as string)))
                return (validation ?? new ValidationGuard()).AddException(new ArgumentNullException(paramName, $"Null value of type {typeof(T)}."));
            else
                return validation;
        }

        public static ValidationGuard IsNotNullValueType<T>(this ValidationGuard validation, Nullable<T> value, string paramName) where T : struct
        {
            if (value == null)
                return (validation ?? new ValidationGuard()).AddException(new ArgumentNullException(paramName, $"Null value of type {typeof(T)}."));
            else
                return validation;
        }

        public static ValidationGuard IsNotDefault<T>(this ValidationGuard validation, T value, string paramName) where T : class
        {
            if (value == default(T))
                return (validation ?? new ValidationGuard()).AddException(new ArgumentException($"{paramName} of type {typeof(T)} cannot be default value {value}."));
            else
                return validation;
        }

        public static ValidationGuard IsNotDefaultValueType<T>(this ValidationGuard validation, T value, string paramName) where T : struct
        {
            if (value.Equals(default(T)))
                return (validation ?? new ValidationGuard()).AddException(new ArgumentException($"{paramName} of type {typeof(T)} cannot be default value {value}"));
            else
                return validation;
        }
        #endregion

        #region Validate Formats
        public static ValidationGuard IsValidEmail(this ValidationGuard validation, string email, string paramName, string regex = RegularExpressions.Email)
        {
            if (!Regex.IsMatch(email, regex))
                return (validation ?? new ValidationGuard()).AddException(new FormatException($"{paramName} is an invalid email. Value provided: {email}."));
            else
                return validation;
        }
        
        public static ValidationGuard IsValidPhone(this ValidationGuard validation, string phone, string paramName, string regex = RegularExpressions.Phone)
        {
            if (!Regex.IsMatch(phone, regex))
                return (validation ?? new ValidationGuard()).AddException(new FormatException($"{paramName} is an invalid phone number. Value provided: {phone}."));
            else
                return validation;
        }

        public static ValidationGuard IsValidZip(this ValidationGuard validation, string zip, string paramName, string regex = RegularExpressions.Zip)
        {
            if (!Regex.IsMatch(zip, regex))
                return (validation ?? new ValidationGuard()).AddException(new FormatException($"{paramName} is an invalid zip code. Value provided: {zip}."));
            else
                return validation;
        }
        #endregion

        #region Validate Numerics
        public static ValidationGuard IsPositive(this ValidationGuard validation, long value, string paramName)
        {
            if (value < 0)
                return (validation ?? new ValidationGuard()).AddException(new ArgumentOutOfRangeException(paramName, $"Must be positive, but was {value}."));
            else
                return validation;
        }

        public static ValidationGuard IsNegative(this ValidationGuard validation, long value, string paramName)
        {
            if (value > 0)
                return (validation ?? new ValidationGuard()).AddException(new ArgumentOutOfRangeException(paramName, $"Must be negative, but was {value}."));
            else
                return validation;
        }

        public static ValidationGuard IsGreaterThanZero(this ValidationGuard validation, int value, string paramName)
        {
            if (value <= 0)
                return (validation ?? new ValidationGuard()).AddException(new ArgumentOutOfRangeException(paramName, $"Must be greater than zero, but was {value}."));
            else
                return validation;
        }

        public static ValidationGuard IsLessThanZero(this ValidationGuard validation, int value, string paramName)
        {
            if (value >= 0)
                return (validation ?? new ValidationGuard()).AddException(new ArgumentOutOfRangeException(paramName, $"Must be less than zero, but was {value}."));
            else
                return validation;
        }
        #endregion

        #region Validate Dates
        public static ValidationGuard IsValidDateRange(this ValidationGuard validation, DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                return (validation ?? new ValidationGuard()).AddException(new InvalidOperationException($"Starting date ({startDate}) cannot be greater than ending date ({endDate}) in range calculations."));
            else
                return validation;
        }

        public static ValidationGuard DateIsSet(this ValidationGuard validation, DateTime date, string paramName)
        {
            if (!date.HasValue())
                return (validation ?? new ValidationGuard()).AddException(new ArgumentNullException(paramName, $"DateTime value is not set. Value = {date}"));
            else
                return validation;
        }
        #endregion

        #region ValidateComparisons
        public static ValidationGuard AreNotEqual<T>(this ValidationGuard validation, T value, T comparingValue, string validationMessage = "Values are not allowed to be equal to each other.")
        {
            if (value.Equals(comparingValue))
                return (validation ?? new ValidationGuard()).AddException(new InvalidOperationException($"{validationMessage} Type:{typeof(T)} {nameof(value)}:{value} {nameof(comparingValue)}:{comparingValue}"));
            else
                return validation;
        }

        public static ValidationGuard AreEqual<T>(this ValidationGuard validation, T value, T comparingValue, string validationMessage = "Values must be equal to each other.")
        {
            if (!value.Equals(comparingValue))
                return (validation ?? new ValidationGuard()).AddException(new InvalidOperationException($"{validationMessage} Type:{typeof(T)} {nameof(value)}:{value} {nameof(comparingValue)}:{comparingValue}"));
            else
                return validation;
        }
        #endregion
    }
}
