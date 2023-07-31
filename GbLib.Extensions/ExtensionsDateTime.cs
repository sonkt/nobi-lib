namespace GbLib.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="ExtensionsDateTime" />.
    /// </summary>
    public static class ExtensionsDateTime
    {
        #region Methods

        public static DateTime AddDaysWithoutLeapYear(this DateTime input, int days)
        {
            DateTime output = input;

            if (days == 0)
                return output;

            int increment = days > 0
                ? 1
                : -1;
            int daysAbs = Math.Abs(days);
            int daysAdded = 0;
            while (daysAdded < daysAbs)
            {
                output = output.AddDays(increment);
                if (!(output.Month == 2 &&
                      output.Day == 29))
                    daysAdded++;
            }

            return output;
        }

        public static IEnumerable<DateTime> GetDatesTo(this DateTime date, DateTime lastDate, TimeSpan span)
        {
            DateTime currentDate = date;
            yield return currentDate;

            int direction = date <= lastDate ? 1 : -1;
            TimeSpan increment = span.MultiplyBy(direction);
            bool IsLastDateReached(DateTime current)
            {
                return direction > 0 ? current > lastDate : current < lastDate;
            }

            currentDate += increment;
            bool lastDateReached = IsLastDateReached(currentDate);
            while (!lastDateReached)
            {
                yield return currentDate;

                currentDate += increment;
                lastDateReached = IsLastDateReached(currentDate);
            }
        }

        public static IEnumerable<DateTime> GetDaysTo(this DateTime date, DateTime lastDay) => GetDatesTo(date, lastDay, new TimeSpan(1, 0, 0, 0));

        public static bool IsFebruary29S(this DateTime date) => date.Day == 29 &&
                   date.Month == 2;

        public static DateTime Max(params DateTime[] days) => days.Max();

        public static DateTime Min(params DateTime[] days) => days.Min();

        public static DateTime Substract(this DateTime date, TimeSpan span) => date.Add(span.MultiplyBy(-1));
        public static DateTime ConvertStringToDateTime(this string strDateTime)
        {
            DateTime dateTime;
            DateTime.TryParseExact(strDateTime, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);
            return dateTime;
        }

        public static string Substract(this DateTime endDate, DateTime startDate)
        {
            try
            {
                TimeSpan thoiGian = endDate - startDate;
                var totalMinutes = (int)thoiGian.TotalMinutes;  // Số phút 
                int hour = totalMinutes / 60;
                int minute = totalMinutes % 60;

                string result = string.Empty;
                if (hour > 0)
                {
                    result = $"{hour} giờ {minute} phút";
                }
                else
                {
                    result = $"{minute} phút";
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Không thể tính thời gian giữa 2 khoảng thời gian {startDate} và {endDate},error : " + ex.Message);
                return string.Empty;
            }
        }


        public static DateTime ParseDate(this string dateString)
        {
            string strDateTime = dateString.Trim();
            if (strDateTime.Contains("|"))
                strDateTime = strDateTime.Replace("|", " ").Trim();
            DateTime result;
            string[] formats = { "yyyy-MM-dd", "yyyyMMdd", "yyyy/MM/dd", "yyyy\\MM\\dd" };
            if (!DateTime.TryParseExact(strDateTime, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                throw new ArgumentException("Invalid date format");
            }
            return result;
        }

        public static DateTime ConvertDateWhenUsingAttendanceExcel(string inputDay, string inputHour)
        {
            // xử lý ngày 
            try
            {
                string[] arrayDate = inputDay.Split('/');
                string[] arrayHour = inputHour.Split(":");
                int year = (arrayDate[2].Length == 2) ? int.Parse($"20{arrayDate[2]}") : int.Parse(arrayDate[2]);

                int month = int.Parse(arrayDate[1]);
                int day = int.Parse(arrayDate[0]);

                int hour = int.Parse(arrayHour[0]);
                int minute = int.Parse(arrayHour[1]);
                int second = int.Parse(arrayHour[2]);
                return new DateTime(year, month, day, hour, minute, second);
            }
            catch (Exception ex)
            {
                Console.WriteLine("can't create date");
                throw;
            }

        }

        public static DateTime ConvertDateWhenUsingAttendanceExcel(this string inputDay)
        {
            // xử lý ngày 
            try
            {
                string[] arrayDate = inputDay.Split('/');
                int year = int.Parse($"20{arrayDate[2]}");
                int month = int.Parse(arrayDate[0]);
                int day = int.Parse(arrayDate[1]);


                return new DateTime(year, month, day);
            }
            catch (Exception ex)
            {
                Console.WriteLine("can't create date");
                throw;
            }

        }
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
        public static DateTime EndOfWeek(this DateTime date, DayOfWeek startOfWeek)
        {
            DateTime firstDayInWeek = date.StartOfWeek(startOfWeek);
            return firstDayInWeek.AddDays(6);
        }

        public static DateTime StartOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }
        public static DateTime EndOfMonth(this DateTime date)
        {
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            return firstDayOfMonth.AddMonths(1).AddSeconds(-1);
        }

        public static DateTime StartOfQuater(this DateTime date)
        {
            int currQuarter = (date.Month - 1) / 3 + 1;

            return new DateTime(date.Year, 3 * currQuarter - 2, 1);
        }
        public static DateTime EndOfQuater(this DateTime date)
        {
            int currQuarter = (date.Month - 1) / 3 + 1;
            return new DateTime(date.Year, 3 * currQuarter + 1, 1).AddDays(-1);
        }
        public static DateTime StartOfYear(this DateTime date)
        {
            return new DateTime(date.Year, 1, 1);
        }
        public static DateTime EndOfYear(this DateTime date)
        {
            return new DateTime(date.Year, 12, 31);
        }
        #endregion Methods
    }
}