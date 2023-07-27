using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbLib.Jaeger
{
    public class JaegerOptions
    {
        #region Properties

        public bool Enabled { get; set; }

        public int MaxPacketSize { get; set; }

        public string ServiceName { get; set; }

        public string UdpHost { get; set; }

        public int UdpPort { get; set; }

        #endregion Properties
    }
}
