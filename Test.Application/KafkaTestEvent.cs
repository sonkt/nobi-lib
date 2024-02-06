using GbLib.Base;
using GbLib.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application
{
    [BusEvent("analytics-test-key","analytics-test-topic")]
    public class KafkaTestEvent: EventBase
    {
        public string? Message { get; set; }
        public string? MessageId { get; set; }
    }
}
