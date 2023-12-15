using GbLib.Base;
using GbLib.RabbitMQ;

namespace Test
{
    [BusEvent("test_exchange", "test_event", "test_event", true, false)]
    public class TestEvent : EventBase
    {
        public string TestCode { get; set; }
        public string TestName { get; set; }
    }
}
