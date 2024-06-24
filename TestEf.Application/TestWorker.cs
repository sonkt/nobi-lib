using GbLib.Worker;
using Microsoft.Extensions.Logging;

namespace TestEf.Application
{
    public class TestWorker : BaseWorker
    {
        public TestWorker(ILogger<BaseWorker> logger) : base(logger)
        {
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var result = await WaitForNextSchedule("0  48 15 24 6 *", Cronos.CronFormat.IncludeSeconds, "SE Asia Standard Time");
                if (!result)
                {
                    Console.WriteLine($"[*] {this.GetType().Name} gia hạn thời gian chờ lịch {DateTime.Now.ToString("hh:mm:ss:fff dd/MM/yyyy")}");
                }
                else
                {
                    Console.WriteLine($"Thực thi job trong 5 phút từ {DateTime.Now.ToString("hh:mm:ss:fff dd:MM:yyyy")}");
                    Task.Delay(300000).Wait();
                }
            }
        }
    }
}