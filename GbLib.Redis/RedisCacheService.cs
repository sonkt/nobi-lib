using Newtonsoft.Json;
using StackExchange.Redis;
using System.Text;

namespace GbLib.Redis
{
    public class RedisCacheService : IRedisCache
    {
        #region Fields

        private readonly IRedisConnectionWrapper _connectionWrapper;

        #endregion Fields

        #region Constructors

        public RedisCacheService(IRedisConnectionWrapper connectionWrapper)
        {
            if (connectionWrapper == null)
                throw new ArgumentNullException("connectionWrapper");

            _connectionWrapper = connectionWrapper;
        }

        #endregion Constructors

        #region Methods

        public virtual void Clear()
        {
            foreach (var ep in _connectionWrapper.GetEndPoints())
            {
                var server = _connectionWrapper.GetServer(ep);
                var keys = server.Keys(database: _connectionWrapper.GetDatabase().Database);
                foreach (var key in keys)
                    Remove(key);
            }
        }

        public virtual void Dispose()
        {
            _connectionWrapper?.Dispose();
        }

        public virtual T Get<T>(string key)
        {
            try
            {
                var rValue = _connectionWrapper.GetDatabase().StringGet(key);
                if (!rValue.HasValue)
                    return default(T);
                var result = Deserialize<T>(rValue);
                return result;
            }
            catch
            {
                return default(T);
            }
        }

        public T[] Get<T>(string[] keys)
        {
            var redisKeys = keys?.Select(m => (RedisKey)m)?.ToList();
            if (redisKeys == null || redisKeys.Count() == 0) return default(T[]);
            List<RedisValue> rValues = new List<RedisValue>();
            RedisValue[] arValue = new RedisValue[] { };

            var offset = 1000;
            var total = redisKeys.Count();
            int count = total / offset;

            for (int i = 0; i <= count; i++)
            {
                var part = redisKeys.Skip(offset * i).Take(offset)?.ToArray();
                if (part != null)
                {
                    rValues.AddRange(_connectionWrapper.GetDatabase().StringGet(part).ToList());
                }
            }

            List<T> listReturn = new List<T>();
            rValues.ForEach(rVal =>
            {
                listReturn.Add(Deserialize<T>(rVal));
            });
            return listReturn.ToArray();
        }

        public KeyValuePair<string, T>[] GetByPattern<T>(string pattern)
        {
            var _db = _connectionWrapper.GetDatabase();
            List<KeyValuePair<string, T>> result = new List<KeyValuePair<string, T>>();
            var command = _db.Execute("keys", pattern);
            if (command != null)
            {
                var keys = (RedisKey[])command;
                var vals = _db.StringGet((RedisKey[])keys);
                for (int i = 0; i < vals.Length; i++)
                {
                    if (vals[i].HasValue)
                    {
                        result.Add(new KeyValuePair<string, T>(keys[i], Deserialize<T>(vals[i])));
                    }
                }
            }

            return result.ToArray();
        }

        public virtual T Hget<T>(string key, string field)
        {
            var rValue = _connectionWrapper.GetDatabase().HashGet(key, field);
            if (!rValue.HasValue)
                return default(T);
            var result = Deserialize<T>(rValue);

            return result;
        }

        public void Hset(string key, HashEntry[] data, int cacheTime)
        {
            if (data == null || !data.Any())
                return;
            try
            {
                _connectionWrapper.GetDatabase().HashSet(key, data);
                if (cacheTime > 0)
                {
                    var expiresIn = TimeSpan.FromMinutes(cacheTime);
                    _connectionWrapper.GetDatabase().KeyExpire(key, expiresIn);
                }
            }
            catch (Exception) { return; }
        }

        public void Hset(string key, string field, object data, int cacheTime)
        {
            if (data == null)
                return;

            var entryBytes = Serialize(data);
            _connectionWrapper.GetDatabase().HashSet(key, field, entryBytes);
            if (cacheTime > 0)
            {
                var expiresIn = TimeSpan.FromMinutes(cacheTime);
                _connectionWrapper.GetDatabase().KeyExpire(key, expiresIn);
            }
        }

        public virtual bool IsSet(string key)
        {
            return _connectionWrapper.GetDatabase().KeyExists(key);
        }

        public virtual void Remove(string key)
        {
            _connectionWrapper.GetDatabase().KeyDelete(key);
        }

        public virtual void RemoveByPattern(string pattern)
        {
            foreach (var ep in _connectionWrapper.GetEndPoints())
            {
                var server = _connectionWrapper.GetServer(ep);
                var keys = server.Keys(database: _connectionWrapper.GetDatabase().Database, pattern: "*" + pattern + "*");
                foreach (var key in keys)
                    Remove(key);
            }
        }

        public virtual void Set(KeyValuePair<string, object>[] values, int cacheTime)
        {
            if (values == null)
            {
                return;
            }
            if (values.Length <= 0)
            {
                return;
            }
            List<KeyValuePair<RedisKey, RedisValue>> tempList = new List<KeyValuePair<RedisKey, RedisValue>>();
            var database = _connectionWrapper.GetDatabase();
            var expiresIn = TimeSpan.FromMinutes(cacheTime);
            foreach (var item in values)
            {
                var jsonString = JsonConvert.SerializeObject(item.Value);
                var dataToCache = Encoding.UTF8.GetBytes(jsonString);
                database.StringSetAsync(item.Key, dataToCache, expiresIn);
            }
        }

        public virtual void Set(string key, object data, int cacheTime)
        {
            if (data == null)
                return;

            var entryBytes = Serialize(data);
            var expiresIn = TimeSpan.FromMinutes(cacheTime);

            _connectionWrapper.GetDatabase().StringSet(key, entryBytes, expiresIn);
        }

        public void SetToCache(List<KeyValuePair<string, object>> tempList, int offset, int cacheTime)
        {
            var total = tempList.Count;
            int count = total / offset;
            for (int i = 0; i <= count; i++)
            {
                var part = tempList.Skip(offset * i).Take(offset)?.ToArray();
                if (part != null)
                {
                    Set(part, cacheTime);
                }
            }
        }

        public virtual T Deserialize<T>(byte[] serializedObject)
        {
            if (serializedObject == null)
                return default(T);

            var jsonString = Encoding.UTF8.GetString(serializedObject);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public virtual byte[] Serialize(object item)
        {
            var jsonString = JsonConvert.SerializeObject(item);
            return Encoding.UTF8.GetBytes(jsonString);
        }

        #endregion Methods
    }
}