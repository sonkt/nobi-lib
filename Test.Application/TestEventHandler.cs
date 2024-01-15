using GbLib.Base;
using GbLib.RMQ;
using Test.Application.RabbitMqEvent;

namespace Test.Application
{
    public class TestEventHandler : IRabbitEventHandler<TestEvent>
    {
        public Task HandleAsync(TestEvent _event)
        {
            Console.WriteLine($"[GbLib]: Đã nhận data từ Rabbit {_event.TestCode} - {_event.TestName}");
            return Task.CompletedTask;
        }

    }
}
