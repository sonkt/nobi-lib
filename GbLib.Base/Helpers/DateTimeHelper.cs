using System.Globalization;

namespace GbLib.Base.Helpers
{
    public static class DateTimeHelper
    {
        #region Constants

        public const string dd_MM_yyyy = "dd/MM/yyyy";

        public const string h_mm_ss_tt = "h:mm:ss tt";

        public const string h_mm_tt = "h:mm tt";

        public const string HH_mm = "HH:mm";

        public const string HH_mm_ss = "HH:mm:ss";

        public const string HhMmDdMmYyyy = "HH:mm dd/MM/yyyy";

        public const string HHmmMMddyyyy = "HH:mm MM/dd/yyyy";

        public const string MM_dd_yyyy = "MM/dd/yyyy";

        public const string yyyy_MM_dd = "yyyy/MM/dd";

        #endregion Constants

        #region Properties

        public static DateTime MinSystemDate
        {
            get { return new DateTime(1753, 1, 1); }
        }

        #endregion Properties

        #region Methods

        public static string ConvertTime(object minutes)
        {
            string ret = string.Empty;
            try
            {
                if (minutes == null) return ret;

                int minute = Convert.ToInt32(minutes);
                ret = $"{(minute / 60)}h:{(minute % 60)}";
            }
            catch
            {
                ret = string.Empty;
            }
            return ret;
        }

        public static string ConvertTimeQcvn(object minutes)
        {
            string ret = string.Empty;
            try
            {
                if (minutes == null) return ret;

                int minute = Convert.ToInt32(minutes);

                int hour = minute / 60;
                var hourStr = hour.ToString();
                if (hour < 10)
                {
                    hourStr = "0" + hourStr;
                }

                minute = minute % 60;
                var minuteStr = minute.ToString();

                if (minute < 10)
                {
                    minuteStr = "0" + minuteStr;
                }

                ret = $"{hourStr}:{minuteStr}";
            }
            catch
            {
                ret = string.Empty;
            }
            return ret;
        }

        public static int DateTimeToUnixTimestampUtc(DateTime dateTime)
        {
            var span = (dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
            double unixTime = span.TotalSeconds;
            return (int)unixTime;
        }

        public static string DisplayDateTime(object dateTime, DateTime fromDate, DateTime toDate)
        {
            string ret = string.Empty;
            try
            {
                DateTime date = DateTime.Parse(dateTime.ToString());

                if (date <= MinSystemDate) return ret;

                string formattime = string.Empty;
                string formatdate = string.Empty;

                CultureInfo culture = Thread.CurrentThread.CurrentCulture;

                if (fromDate.Date.Equals(toDate.Date))
                {
                    formattime = HH_mm;
                }
                else
                {
                    if (culture.TwoLetterISOLanguageName.Equals("vi", StringComparison.InvariantCultureIgnoreCase))
                    {
                        formattime = HH_mm;
                        formatdate = dd_MM_yyyy;
                    }
                    else
                    {
                        formattime = HH_mm;
                        formatdate = MM_dd_yyyy;
                    }
                }

                string formatString = (!string.IsNullOrEmpty(formatdate)) ? $"{formattime} {formatdate}" : formattime;

                ret = date.ToString(formatString);
            }
            catch
            {
            }
            return ret;
        }

        public static DateTime EndHourInDay(DateTime dt)
        {
            var endDate = DateTime.Parse(dt.ToString(MM_dd_yyyy)).AddDays(1).AddTicks(-2).ToString(CultureInfo.InvariantCulture);
            return DateTime.Parse(endDate).Date.AddDays(1).AddTicks(-1);
        }

        public static string FormatDate(object dt)
        {
            return FormatDate(dt, string.Empty);
        }

        public static string FormatDate(object dt, string defaultValue)
        {
            string ret = defaultValue;
            try
            {
                DateTime date = DateTime.Parse(dt.ToString());
                string formatdate;

                formatdate = dd_MM_yyyy;

                ret = (date == DateTime.MinValue || date == MinSystemDate) ? defaultValue : date.ToString(formatdate);
            }
            catch
            {
                ret = string.Empty;
            }
            return ret;
        }

        public static string FormatDateTime(object dt)
        {
            string ret;
            try
            {
                DateTime date = DateTime.Parse(dt.ToString());
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string formatRegion = HHmmMMddyyyy;
                if (culture.Name == "vi" || culture.Name == "vi-VN")
                    formatRegion = HhMmDdMmYyyy;
                ret = (date == DateTime.MinValue || date == MinSystemDate || date.Date == DateTime.MaxValue.Date) ? string.Empty : date.ToString(formatRegion);
            }
            catch
            {
                ret = string.Empty;
            }
            return ret;
        }

        public static DateTime GenerateDateTime()
        {
            return DateTimeOffset.Now.UtcDateTime;
        }

        public static DateTime? ParseDate(string date)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            return ParseDate(date, culture);
        }

        public static DateTime? ParseDate(string date, CultureInfo culture)
        {
            try { return DateTime.ParseExact(date, culture.DateTimeFormat.ShortDatePattern, culture); }
            catch { return null; }
        }

        public static DateTime? ParseDateTime(string time, string date)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            return ParseDateTime(time, date, culture);
        }

        public static DateTime? ParseDateTime(string time, string date, CultureInfo culture)
        {
            try
            {
                string dt = string.Empty;
                if (string.IsNullOrEmpty(time))
                {
                    dt = date;
                }
                else
                {
                    dt = $"{time} {date}";
                }

                return DateTime.Parse(dt, culture, DateTimeStyles.NoCurrentDateDefault);
            }
            catch
            {
                return null;
            }
        }

        public static DateTime? ParseExactDateTime(string date, string format)
        {
            return ParseExactDateTime(date, format, CultureInfo.InvariantCulture);
        }

        public static DateTime? ParseExactDateTime(string date, string format, IFormatProvider provider)
        {
            try { return DateTime.ParseExact(date, format, provider); }
            catch
            {
                return null;
            }
        }

        public static DateTime StartHourInDay(DateTime dt)
        {
            var startDate = DateTime.Parse(dt.ToString(MM_dd_yyyy)).AddTicks(1).ToString(CultureInfo.InvariantCulture);
            return DateTime.Parse(startDate).Date;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public static DateTime ToDateTimeFromEpoch(this long intDate)
        {
            var timeInTicks = intDate * TimeSpan.TicksPerSecond;
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddTicks(timeInTicks);
        }

        public static DateTime ToLocalDateTime(this long unixDate, bool inTick = false)
        {
            if (inTick)
            {
                var timeInTicks = unixDate * TimeSpan.TicksPerSecond;
                return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddTicks(timeInTicks).ToLocalTime();
            }
            else
            {
                return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixDate).ToLocalTime();
            }
        }

        public static long ToEpochFromDateTime(this DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return diff.Ticks / TimeSpan.TicksPerSecond;
        }

        public static DateTime ConvertToTimeZone(this DateTime dateTime, string timeZoneId = "SE Asia Standard Time")
        {
            var time = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return TimeZoneInfo.ConvertTimeFromUtc(time, timeZone);
        }

        public static DateTime ConvertFromTimeZone(this DateTime dateTime, string timeZoneId = "SE Asia Standard Time")
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return TimeZoneInfo.ConvertTimeToUtc(dateTime, timeZone);
        }

        #endregion Methods
    }
}