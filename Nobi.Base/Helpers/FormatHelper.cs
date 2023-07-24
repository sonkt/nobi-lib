namespace Nobi.Base.Helpers
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Defines the <see cref="FormatHelper" />.
    /// </summary>
    public class FormatHelper
    {
        #region Constants

        protected const string FormatDoubleString = "#,###,###,##0.###";

        #endregion Constants

        #region Properties

        protected static CultureInfo DefaultCulture
        {
            get
            {
                return new CultureInfo("vi-VN");
            }
        }

        #endregion Properties

        #region Methods

        public static double ConvertToDouble(object obj)
        {
            return ConvertToDouble(obj, 2);
        }

        public static double ConvertToDouble(object obj, int numAfterComma)
        {
            return ConvertToDouble(obj, numAfterComma, new CultureInfo("en-US"));
        }

        public static double ConvertToDouble(object obj, int numAfterComma, CultureInfo culture)
        {
            double ret = 0;
            try
            {
                double.TryParse(obj.ToString(), NumberStyles.Float, culture, out ret);

                if (ret > 0)
                {
                    ret = Math.Round(ret, numAfterComma, MidpointRounding.AwayFromZero);
                }
            }
            catch
            {
            }
            return ret;
        }

        public static string FormatDouble(object obj)
        {
            return FormatDouble(obj, 2);
        }

        public static string FormatDouble(object obj, int digits)
        {
            string ret = string.Empty;
            if (obj == null) return ret;
            try
            {
                ret = Math.Round(Convert.ToDouble(obj), digits).ToString(FormatDoubleString, DefaultCulture);
            }
            catch
            {
            }
            return ret;
        }

        public static string FormatDouble(object obj, int number, CultureInfo culture)
        {
            string ret = string.Empty;
            if (obj == null) return ret;
            try
            {
                ret = Math.Round(Convert.ToDouble(obj), number, MidpointRounding.AwayFromZero).ToString(FormatDoubleString, culture);
            }
            catch
            {
            }
            return ret;
        }

        public static string FormatDoubleChar(object obj, CultureInfo culture, int digits, string defaultChar)
        {
            string ret = defaultChar;
            if (obj == null) return ret;
            try
            {
                ret = (!Convert.ToDouble(obj).Equals(0)) ? Math.Round(Convert.ToDouble(obj), digits, MidpointRounding.AwayFromZero).ToString(FormatDoubleString, culture) : defaultChar;
            }
            catch
            {
                ret = defaultChar;
            }
            return ret;
        }

        public static string FormatHourMinuteStr(int minutes)
        {
            if (minutes < 0) return string.Empty;

            var hourPart = minutes / 60;
            var minPart = minutes % 60;

            var hourPartStr = hourPart.ToString();
            var minPartStr = minPart.ToString();

            if (hourPart < 10)
            {
                hourPartStr = "0" + hourPartStr;
            }

            if (minPart < 10)
            {
                minPartStr = "0" + minPartStr;
            }

            return hourPartStr + ":" + minPartStr;
        }

        public static double RoundDouble(double obj)
        {
            return RoundDouble(obj, 3);
        }

        public static double RoundDouble(double obj, int number)
        {
            double ret = 0;
            try
            {
                ret = Math.Round(Convert.ToDouble(obj), number);
            }
            catch
            {
            }
            return ret;
        }

        #endregion Methods
    }
}