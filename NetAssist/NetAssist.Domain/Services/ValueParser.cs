using System;

namespace NetAssist.Domain
{
    public class ValueParser : IValueParser
    {
        public virtual bool IsAcceptedType(Type type)
        {
            return type == typeof(string) ||
               type == typeof(bool) ||
               type == typeof(int) ||
               type == typeof(decimal) ||
               type == typeof(double) ||
               type == typeof(DateTime) ||
               type == typeof(Guid);
        }

        public virtual T Parse<T>(string value)
        {
            var type = typeof(T);

            if (!IsAcceptedType(type))
                throw new InvalidOperationException($"Type {type.FullName} is not a valid type to parse using {GetType().FullName}.");

            if (type == typeof(string))
                return (T)(value as object);
            else if (type == typeof(bool))
                return (T)(value.ParseToBool() as object);
            else if (type == typeof(int))
                return (T)(value.ParseToInteger() as object);
            else if (type == typeof(decimal))
                return (T)(value.ParseDecimal() as object);
            else if (type == typeof(double))
                return (T)(value.ParseToDouble() as object);
            else if (type == typeof(DateTime))
                return (T)(ParseDateTime(value) as object);
            else if (type == typeof(Guid))
            {
                Guid guidValue;
                if (Guid.TryParse(value, out guidValue))
                    return (T)(guidValue as object);
                else
                    throw new InvalidCastException();
            }
            else
                return default(T);
        }

        protected virtual DateTime ParseDateTime(string value)
        {
            DateTime date;
            if (DateTime.TryParse(value, out date))
                return date;
            else
                throw new FormatException($"Value not in proper DateTime format. Value: {value}");
        }
    }
}
