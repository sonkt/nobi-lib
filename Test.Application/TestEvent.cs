using GbLib.Base;
using GbLib.RMQ;

namespace Test.Application.RabbitMqEvent
{
    [BusEvent("test_exchange","test_event", "test_event", true, false)]
    public class TestEvent : IRabbitEvent
    {
        public string TestCode { get; set; }
        public string TestName { get; set; }
    }
}
