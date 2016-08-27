namespace NetAssist.Domain
{
    public interface ICacheCleaner
    {
        void ClearAll();
        void Clear(CacheComponent cacheComponent);
        void ClearByPath(string outputPath);
        void ClearByAction(CacheAction action);
    }
}
