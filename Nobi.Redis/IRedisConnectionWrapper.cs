using StackExchange.Redis;
using System.Net;

namespace Nobi.Redis
{
    public interface IRedisConnectionWrapper : IDisposable
    {
        #region Methods

        void FlushDatabase(int? db = null);

        IDatabase GetDatabase(int? db = null);

        EndPoint[] GetEndPoints();

        IServer GetServer(EndPoint endPoint);

        bool PerformActionWithLock(string resource, TimeSpan expirationTime, Action action);

        #endregion Methods
    }
}
