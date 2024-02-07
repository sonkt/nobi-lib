using Cronos;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbLib.Worker
{
    public abstract class BaseWorker : BackgroundService
    {
        public readonly ILogger<BaseWorker> _logger;
        public BaseWorker(ILogger<BaseWorker> logger)
        {
            _logger = logger;
        }
        public async Task WaitForNextSchedule(string cronExpression)
        {
            var parsedExp = CronExpression.Parse(cronExpression);
            var currentUtcTime = DateTimeOffset.UtcNow.UtcDateTime;
            var occurenceTime = parsedExp.GetNextOccurrence(currentUtcTime);
            var delay = occurenceTime.GetValueOrDefault() - currentUtcTime;
            await Task.Delay(delay);
        }
    }
}
