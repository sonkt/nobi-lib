using GbLib.Base;
using GbLib.RMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application
{
    public class PingEventHandler : IRabbitEventHandler<PingEvent>
    {    

        public Task HandleAsync(PingEvent _event)
        {
            Console.WriteLine($"[GbLib]: Đã nhận data từ Rabbit {_event.Name}");
            return Task.CompletedTask;
        }
    }
}
