namespace NetAssist.Domain
{
    public interface ISettings
    {
        string Get(string key);
        string Get(string key, bool required);
        string Get(string key, string defaultValue);
        T Get<T>(string key);
        T Get<T>(string key, bool required);
        T Get<T>(string key, T defaultValue);
    }
}
