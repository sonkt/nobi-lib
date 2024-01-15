using GbLib.RMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application
{
    [BusEvent("test_exchange","ping-event","ping-route",true,false)]
    public class PingEvent:IRabbitEvent
    {
        public string Name { get; set; }
    }
}
