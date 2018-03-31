using System;

namespace NetAssist.Domain
{
    public class ValueParser : IValueParser
    {
        public virtual T Parse<T>(string value)
        {
            var type = typeof(T);

            if (type == typeof(string))
                return (T)(value as object);
            else if (type == typeof(bool))
                return (T)(value.ParseToBool() as object);
            else if (type == typeof(int))
                return (T)(value.ParseToInteger() as object);
            else if (type == typeof(decimal))
                return (T)(value.ParseToDecimal() as object);
            else if (type == typeof(double))
                return (T)(value.ParseToDouble() as object);
            else if (type == typeof(DateTime))
                return (T)(value.ParseToDateTime() as object);
            else if (type == typeof(Guid))
                return (T)(value.ParseToGuid() as object);
            else
                throw new InvalidOperationException($"Type {type.FullName} is not a valid type to Parse using {GetType().FullName}.");
        }

        public bool TryParse<T>(string value, out T parsedValue)
        {
            parsedValue = default(T);

            if (string.IsNullOrWhiteSpace(value))
                return false;

            var type = typeof(T);

            if (type == typeof(string))
            {
                parsedValue = (T)(value as object);
                return true;
            }
            else if (type == typeof(bool))
            {
                bool boolValue;
                if (bool.TryParse(value, out boolValue))
                {
                    parsedValue = (T)(boolValue as object);
                    return true;
                }
            }
            else if (type == typeof(int))
            {
                int intValue;
                if (int.TryParse(value, out intValue))
                {
                    parsedValue = (T)(intValue as object);
                    return true;
                }
            }
            else if (type == typeof(decimal))
            {
                decimal decimalValue;
                if (decimal.TryParse(value, out decimalValue))
                {
                    parsedValue = (T)(decimalValue as object);
                    return true;
                }
            }
            else if (type == typeof(double))
            {
                double doubleValue;
                if (double.TryParse(value, out doubleValue))
                {
                    parsedValue = (T)(doubleValue as object);
                    return true;
                }
            }
            else if (type == typeof(DateTime))
            {
                DateTime dateValue;
                if (DateTime.TryParse(value, out dateValue))
                {
                    parsedValue = (T)(dateValue as object);
                    return true;
                }
            }
            else if (type == typeof(Guid))
            {
                Guid guidValue;
                if (Guid.TryParse(value, out guidValue))
                {
                    parsedValue = (T)(guidValue as object);
                    return true;
                }
            }
            else
                throw new InvalidOperationException($"Type {type.FullName} is not a valid type to TryParse using {GetType().FullName}.");

            return false;
        }
    }
}
