namespace NetAssist.Domain
{
    public interface IValueParser
    {
        T Parse<T>(string value);
        bool TryParse<T>(string value, out T parsedValue);
    }
}
