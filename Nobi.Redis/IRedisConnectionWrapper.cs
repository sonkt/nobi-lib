using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
