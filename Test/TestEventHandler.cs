using GbLib.Base;

namespace Test
{
    public class TestEventHandler : IEventHandler<TestEvent>
    {
        public Task HandleAsync(TestEvent _event, ICorrelationContext context)
        {
            Console.WriteLine($"Đã nhận data từ Rabbit {_event.TestCode} - {_event.TestName}");
            return Task.CompletedTask;
        }
    }
}
