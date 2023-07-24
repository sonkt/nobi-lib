using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System.Net;

namespace Nobi.Redis
{
    public class RedisConnectionWrapper : IRedisConnectionWrapper
    {
        #region Fields

        private readonly IDistributedCache _distributedCache;

        private readonly object _lock = new object();

        private readonly IOptions<RedisCacheOptions> _redisOptions;

        private volatile ConnectionMultiplexer _connection;

        #endregion Fields

        #region Constructors

        public RedisConnectionWrapper(IDistributedCache distributedCache,
            IOptions<RedisCacheOptions> redisOptions)
        {
            _distributedCache = distributedCache;
            _redisOptions = redisOptions;
        }

        #endregion Constructors

        #region Methods

        public void Dispose()
        {
            if (_connection != null)
                _connection.Dispose();
        }

        public void FlushDatabase(int? db = null)
        {
            var endPoints = GetEndPoints();

            foreach (var endPoint in endPoints)
            {
                GetServer(endPoint).FlushDatabase(db ?? -1);
            }
        }

        public IDatabase GetDatabase(int? db = null)
        {
            var defaultDb = _redisOptions.Value.ConfigurationOptions.DefaultDatabase.HasValue ? _redisOptions.Value.ConfigurationOptions.DefaultDatabase.Value : -1;
            return GetConnection().GetDatabase(db ?? defaultDb);
        }

        public EndPoint[] GetEndPoints()
        {
            return GetConnection().GetEndPoints();
        }

        public IServer GetServer(EndPoint endPoint)
        {
            return GetConnection().GetServer(endPoint);
        }

        public bool PerformActionWithLock(string resource, TimeSpan expirationTime, Action action)
        {
            return false;
        }

        protected string GetConnectionString()
        {
            return GetConnection().Configuration;
        }

        private ConnectionMultiplexer GetConnection()
        {
            if (_connection != null && _connection.IsConnected) return _connection;

            lock (_lock)
            {
                if (_connection != null && _connection.IsConnected) return _connection;

                _connection?.Dispose();

                if (_redisOptions.Value.Configuration != null)
                {
                    _connection = ConnectionMultiplexer.Connect(_redisOptions.Value.Configuration);
                }
                else
                {
                    _connection = ConnectionMultiplexer.Connect(_redisOptions.Value.ConfigurationOptions);
                }
            }

            return _connection;
        }

        #endregion Methods
    }
}
