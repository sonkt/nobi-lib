using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobi.Redis
{
    public class RedisOptions
    {
        public bool AbortOnConnectFail { get; set; }

        public bool AllowAdmin { get; set; }

        public int ConnectRetry { get; set; }

        public int DefaultDatabase { get; set; }

        public bool Enabled { get; set; }

        public string Host { get; set; }

        public string Password { get; set; }

        public int Port { get; set; }

        public bool ResolveDns { get; set; }

        public string ServiceName { get; set; }
    }
}
