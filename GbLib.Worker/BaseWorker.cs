using Cronos;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GbLib.Worker
{
    public abstract class BaseWorker : BackgroundService
    {
        public readonly ILogger<BaseWorker> _logger;
        public BaseWorker(ILogger<BaseWorker> logger)
        {
            _logger = logger;
        }
        public virtual async Task WaitForNextSchedule(string cronExpression, CronFormat cronFormat= CronFormat.Standard)
        {
            var parsedExp = CronExpression.Parse(cronExpression, cronFormat);
            var currentUtcTime = DateTimeOffset.UtcNow.UtcDateTime;
            var occurenceTime = parsedExp.GetNextOccurrence(currentUtcTime);
            var delay = occurenceTime.GetValueOrDefault() - currentUtcTime;
            await Task.Delay(delay);
        }
    }
}
