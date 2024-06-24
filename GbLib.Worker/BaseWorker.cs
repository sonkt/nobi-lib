using Cronos;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TimeZoneConverter;

namespace GbLib.Worker
{
    public abstract class BaseWorker : BackgroundService
    {
        public readonly ILogger<BaseWorker> _logger;

        public BaseWorker(ILogger<BaseWorker> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Thiết lập lịch thực hiện theo Cron Expression
        /// </summary>
        /// <param name="cronExpression">Biểu thức Cron theo thông tin tại https://github.com/HangfireIO/Cronos</param>
        /// <param name="cronFormat">Định dạng Cron. Mặc định là Standard, có thể chuyển sang dùng theo giây: CronFormat.IncludeSeconds</param>
        /// <param name="timeZone">Chỉ định timezone. Mặc định để trống sẽ sử dụng LocalTime (giờ hệ thống)</param>
        /// <returns></returns>
        public virtual async Task<bool> WaitForNextSchedule(string cronExpression, CronFormat cronFormat = CronFormat.Standard, string timeZone = "")
        {
            var parsedExp = CronExpression.Parse(cronExpression, cronFormat);
            var currentUtcTime = DateTimeOffset.UtcNow.UtcDateTime;
            var timeZoneInfo = string.IsNullOrEmpty(timeZone) ? TimeZoneInfo.Local : TZConvert.GetTimeZoneInfo(timeZone);
            var occurenceTime = parsedExp.GetNextOccurrence(currentUtcTime, timeZoneInfo);

            var delay = occurenceTime.GetValueOrDefault() - currentUtcTime;
            if (delay.TotalDays <= 365)
            {
                await Task.Delay(delay);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}