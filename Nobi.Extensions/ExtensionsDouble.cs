namespace Nobi.Extensions
{
    using System;

    /// <summary>
    /// Defines the <see cref="ExtensionsDouble" />.
    /// </summary>
    public static class ExtensionsDouble
    {
        #region Methods

        public static double DivideBy(this double number, double number2) => number2 <= Utils.Tolerance
                ? double.NaN
                : number / number2;

        public static double ToDegrees(this double radians) => radians * 180.0 / Math.PI;

        public static double ToRadians(this double degrees) => degrees * Math.PI / 180.0;

        public static string ToHourFormat(this double value, bool showSeconds = false)
        {
            if (value != 0)
            {
                var hours = value / 60;
                var rhours = Math.Floor(hours);
                var minutes = value % 60;
                var rminutes = Math.Floor(minutes);
                var seconds = (minutes - rminutes) * 60;
                var rseconds = Math.Round(seconds);
                return (rhours < 10 ? "0" + rhours : rhours) + ":" + (rminutes < 10 ? ":" + rminutes : rminutes) + (showSeconds ? (":" + (rseconds < 10 ? "0" + rseconds : rseconds)) : "");
            }
            else
            {
                return "";
            }
        }

        public static string ToTimeString(this double value, string typeFormat = "hh.mm")
        {
            if (value != 0)
            {
                if (string.IsNullOrEmpty(typeFormat))
                {
                    typeFormat = "hh.mm";
                }
                var hours = value / 60;
                var rhours = Math.Floor(hours) == 0 ? "" : Math.Floor(hours) > 9 ? $"{Math.Floor(hours)}" : $"0{Math.Floor(hours)}";
                var minutes = value % 60;
                var rminutes = Math.Floor(minutes) > 9 ? $"{Math.Floor(minutes)}" : $"0{Math.Floor(minutes)}";
                var seconds = (minutes - Math.Floor(minutes)) * 60;
                var rseconds = Math.Floor(seconds) > 9 ? $"{Math.Floor(seconds)}" : $"0{Math.Floor(seconds)}";

                typeFormat = typeFormat.ToLowerInvariant();

                switch (typeFormat)
                {
                    case "hh:mm:ss": // 20:15:00
                        return (!string.IsNullOrEmpty(rhours) ? (rhours + ":") : "") + rminutes + ":" + rseconds;
                    case "hh:mm": // 20:15
                        return (!string.IsNullOrEmpty(rhours) ? (rhours + ":") : "") + rminutes;
                    case "hh#mm#ss": // 20 giờ 15 phút 00 giây
                        return (!string.IsNullOrEmpty(rhours) ? (rhours + " giờ ") : "") + rminutes + " phút " + rseconds + " giây";
                    case "hh#mm": // 20 giờ 15 phút
                        return (!string.IsNullOrEmpty(rhours) ? (rhours + " giờ ") : "") + rminutes + " phút";
                    case "hh.mm": // 20.25 giờ
                        return $"{string.Format(new System.Globalization.CultureInfo("vi-VN"), "{0:0.##}", hours)} giờ";
                    default:
                        return value + " phút";
                }
            }
            else
            {
                return typeFormat.EndsWith("ss") ? "0 giây" : "0 phút";
            }
        }

        #endregion Methods
    }
}