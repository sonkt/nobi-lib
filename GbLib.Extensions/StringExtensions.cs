namespace GbLib.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Text.Json;

    /// <summary>
    /// Defines the <see cref="StringExtensions" />.
    /// </summary>
    public static class StringExtensions
    {
        #region Fields

        private static readonly string backslashChars = "\u005c\u00a5\u0160\u20a9\u2216\ufe68\uff3c";

        private static readonly CharKinds[] charClassArray = MakeCharClassArray();

        private static readonly string quoteChars =
            "\u0022\u0027\u0060\u00b4\u02b9\u02ba\u02bb\u02bc\u02c8\u02ca\u02cb\u02d9\u0300\u0301\u2018\u2019\u201a\u2032\u2035\u275b\u275c\uff07";

        #endregion Fields

        #region Enums

        private enum CharKinds : byte
        {
            None,
            Quote,
            Backslash
        }

        #endregion Enums

        #region Methods

        public static string MySQLEscape(this string value)
        {
            if (!IsQuoting(value)) return value;

            var sb = new StringBuilder();
            foreach (var c in value)
            {
                var charClass = charClassArray[c];
                if (charClass != CharKinds.None) sb.Append("\\");
                sb.Append(c);
            }

            return sb.ToString();
        }

        public static string TrimAfter(this string source, string trim)
        {
            var index = source.IndexOf(trim, StringComparison.Ordinal);
            if (index > 0) source = source.Substring(0, index);

            return source;
        }

        public static string TrimStart(this string source, string trim,
            StringComparison stringComparison = StringComparison.Ordinal)
        {
            if (source == null) return null;

            var s = source;
            while (s.StartsWith(trim, stringComparison)) s = s.Substring(trim.Length);

            return s;
        }

        private static bool IsQuoting(string str)
        {
            foreach (var c in str)
                if (charClassArray[c] != CharKinds.None)
                    return true;

            return false;
        }

        private static CharKinds[] MakeCharClassArray()
        {
            var a = new CharKinds[65536];
            foreach (var c in backslashChars) a[c] = CharKinds.Backslash;
            foreach (var c in quoteChars) a[c] = CharKinds.Quote;

            return a;
        }

        public static bool IsBase64String(this string base64)
        {
            Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
            return Convert.TryFromBase64String(base64, buffer, out int bytesParsed);
        }

        public static string ToString(this List<string> list, string delimiter)
        {
            return string.Join(", ", list);
        }

        /// <summary>
        /// Get Last Name From StringName
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public static string LastName(this string fullName)
        {
            string name = fullName.Trim();
            var arrName = fullName.Split(' ');
            if (arrName.Count() >= 2)
                return arrName.Last();
            return name;
        }

        /// <summary>
        /// Get First Name From StringName
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public static string FirstName(this string fullName)
        {
            string name = fullName.Trim();
            var arrName = fullName.Split(' ');
            if (arrName.Count() >= 2)
            {
                var index_last_Space = name.LastIndexOf(' ');
                string firstName = name.Remove(index_last_Space);
                return firstName;
            }
            return name;
        }

        /// <summary>
        /// Compate String to Sorting by culture vi-vn
        /// </summary>
        /// <returns></returns>
        public static StringComparer CompareVietNamese()
        {
            var culture = new CultureInfo("vi-vn");
            return StringComparer.Create(culture, false);
        }

        public static T ToJson<T>(this string value)
        {
            if (string.IsNullOrEmpty(value)) return default(T);
            return JsonSerializer.Deserialize<T>(value.ToString(), JsonSerializerOptions.Default);
        }

        public static string ConvertToDateTimeStringKey(this string inputDay)
        {
            try
            {
                string outputDate = inputDay;
                string[] arrayDate = new string[3];
                int year = 0;
                if (inputDay.Length >= 11)
                {
                    DateTime date = DateTime.ParseExact(inputDay, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
                    outputDate = date.ToString("MM/dd/yyyy");
                    arrayDate = outputDate.Split('/');
                    year = int.Parse(arrayDate[2]);
                }
                else
                {
                    arrayDate = outputDate.Split('/');
                    year = int.Parse($"20{arrayDate[2]}");
                }
                int month = int.Parse(arrayDate[0]);
                int day = int.Parse(arrayDate[1]);
                string response = $"{day}/{month}/{year}";
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        #endregion Methods
    }
}