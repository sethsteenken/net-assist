namespace NetAssist.Domain
{
    public interface ICache
    {
        bool Exists(string key);
        void Set(object value, string key);
        void Set(object value, string key, string profile);
        void Set(object value, string key, double minutes);
        void SetNoExpire(object value, string key);
        void Remove(string key);
        void RemoveAll(string keyContains);
        void Clear();
        T Get<T>(string key);
    }
}
