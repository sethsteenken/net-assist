namespace NetAssist.Domain
{
    public interface IValueParser
    {
        T Parse<T>(string value);
    }
}
