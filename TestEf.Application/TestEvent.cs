using GbLib.RabbitMQ;

namespace TestEf.Application
{
    [BusEvent("Test_Exchange","Test_Queue","Test_Key",true,true)]
    public class TestEvent : IRabbitEvent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }
    }
    public class TestEventHandler : IRabbitEventHandler<TestEvent>
    {
        public Task HandleAsync(TestEvent _event)
        {
            Console.WriteLine($"OK: {_event.Code}_{_event.FirstName}_{_event.LastName}");
            return Task.CompletedTask;
        }
    }
}