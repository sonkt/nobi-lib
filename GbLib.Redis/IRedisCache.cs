using StackExchange.Redis;

namespace GbLib.Redis
{
    public interface IRedisCache : IDisposable
    {
        void Clear();

        T Deserialize<T>(byte[] serializedObject);

        T Get<T>(string key);

        T[] Get<T>(string[] key);

        KeyValuePair<string, T>[] GetByPattern<T>(string pattern);

        T Hget<T>(string key, string field);

        void Hset(string key, HashEntry[] data, int cacheTime);

        void Hset(string key, string field, object data, int cacheTime);

        bool IsSet(string key);

        void Remove(string key);

        void RemoveByPattern(string pattern);

        byte[] Serialize(object item);

        void Set(KeyValuePair<string, object>[] values, int cacheTime);

        void Set(string key, object data, int cacheTime);

        void SetToCache(List<KeyValuePair<string, object>> tempList, int offset, int cacheTime);
    }
}