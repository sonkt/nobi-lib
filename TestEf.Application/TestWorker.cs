using GbLib.Extensions;
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
                var result = await WaitForNextSchedule("0  48 10 24 6 MON", Cronos.CronFormat.IncludeSeconds, "SE Asia Standard Time");
                if (!result)
                {
                    _ = this.StopAsync(stoppingToken);
                    Console.WriteLine($"[*] {this.GetType().Name} đã dừng lúc {DateTime.Now.ToString("hh:MM:ss dd/MM/yyyy")}");
                }
            }
        }
    }
}