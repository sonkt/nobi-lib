using GbLib.Base;
using GbLib.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application
{
    public class KafkaTestEventHandler : IEventHandler<KafkaTestEvent>
    {
        public Task HandleAsync(KafkaTestEvent _event, ICorrelationContext context)
        {
            Console.WriteLine("Đã nhận data từ Kafka");
            return Task.CompletedTask;
        }
    }
}
