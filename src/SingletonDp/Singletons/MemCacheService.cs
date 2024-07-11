namespace SingletonDp.Singletons;

public class MemCacheService
{
    private static MemCacheService? _instance;
    private readonly Dictionary<string, object> _cache;

    private MemCacheService()
    {
        _cache = new Dictionary<string, object>();
    }

    public static MemCacheService Instance => _instance ??= new MemCacheService();

    public void Set<T>(string key, T value)
    {
        _cache[key] = value;
    }

    public T Get<T>(string key)
    {
        return (T)_cache[key];
    }
}