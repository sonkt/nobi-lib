namespace Nobi.Base.Helpers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Defines the <see cref="StringHelper" />.
    /// </summary>
    public class StringHelper
    {
        #region Fields

        public static readonly Regex IsVietNamChar = new Regex("^[" + string.Join("", VietNamChar) + "0-9]+", RegexOptions.Compiled);

        private static readonly Regex Pattern = new Regex("[<>\"']");

        public static string[] VietNamChar = new string[]
        {
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };

        #endregion Fields

        #region Methods

        public static string ConvertIntToHex(int value)
        {
            return value.ToString("X").PadLeft(6, '0');
        }

        public static string ConvertToDashesVn(string input)
        {
            StringBuilder sb = new StringBuilder();
            char[] ca = input.Trim().ToCharArray();
            foreach (char t in ca)
            {
                char x = ConvertedVnChar(t);
                if (x != '@')
                    sb.Append(x);
            }

            return Regex.Replace(sb.ToString(), @"-+", "-").Trim('-').ToLower();
        }

        public static string ConvertToUnderlinedVn(string input)
        {
            StringBuilder sb = new StringBuilder();
            char[] ca = input.Trim().ToCharArray();
            foreach (char t in ca)
            {
                char x = ConvertedVnChar(t);
                if (x != '@')
                    sb.Append(x);
            }

            return Regex.Replace(sb.ToString(), @"-+", "_").Trim('_').ToLower();
        }

        public static string ConvertToVn(string input)
        {
            StringBuilder sb = new StringBuilder();
            char[] ca = input.Trim().ToCharArray();
            foreach (char t in ca)
            {
                char x = ConvertedVnChar(t);
                if (x != '@')
                    sb.Append(x);
            }

            return Regex.Replace(sb.ToString(), @"-+", " ").Trim(' ').ToLower();
        }

        public static string EncryptPassword(string password)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] hashBytes = encoding.GetBytes(password);

            SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider();

            byte[] cryptPassword = sha512.ComputeHash(hashBytes);

            return Convert.ToBase64String(cryptPassword);
        }

        public static string GenerateRandomString(int length, string chars)
        {
            var random = new Random();

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RemoveDangerousChars(string text, bool isRemove = true)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(text)) return string.Empty;
                text = text.Trim();
                text = WebUtility.HtmlDecode(text);
                var r = new Regex(@"\s+");
                text = r.Replace(text, @" ");
                text = Regex.Replace(text, @"<(.|\n)*?>", string.Empty);

                if (isRemove)
                {
                    text = Pattern.Replace(text, string.Empty);
                    text = text.Replace("/", "|").Replace("\\", "|").Replace("[&]", "&").Replace("&", "[&]");
                }
            }
            catch
            {
                return string.Empty;
            }
            return text;
        }

        public static string ToMD5(string str)
        {
            string result = "";
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            for (int i = 0; i < buffer.Length; i++)
            {
                result += buffer[i].ToString("x2");
            }
            return result;
        }

        public static string Uni2KD2(string strKD)
        {
            string retVal = strKD;
            try
            {
                string[] arKD = {"a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
                                                "a", "a", "a", "a", "a", "a", "e", "e", "e", "e", "e", "e", "e", "e",
                                                "e", "e", "e", "d", "i", "i", "i", "i", "i", "o", "o", "o", "o", "o", "o",
                                                "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "u", "u", "u",
                                                "u", "u", "u", "u", "u", "u", "u", "u", "y", "y", "y", "y", "y",
                                                "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A",
                                                "A", "A", "A", "A", "A", "A", "E", "E", "E", "E", "E", "E", "E", "E",
                                                "E", "E", "E", "D", "I", "I", "I", "I ", "I ", "O", "O", "O", "O", "O", "O",
                                                "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "U", "U", "U",
                                                "U", "U", "U", "U", "U", "U", "U", "U", "Y", "Y", "Y", "Y", "Y"};

                string[] arUni = {"à", "á", "ả", "ã", "ạ", "ầ", "ấ", "ẩ", "ẫ", "ậ", "â",
                                                 "ằ", "ắ", "ẳ", "ẵ", "ặ", "ă", "è", "é", "ẻ", "ẽ", "ẹ", "ề", "ế", "ể",
                                                 "ễ", "ệ", "ê", "đ", "ì", "í", "ỉ", "ĩ", "ị", "ò", "ó", "ỏ", "õ", "ọ", "ồ",
                                                 "ố", "ổ", "ỗ", "ộ", "ô", "ờ", "ớ", "ở", "ỡ", "ợ", "ơ", "ù", "ú", "ủ",
                                                 "ũ", "ụ", "ừ", "ứ", "ử", "ữ", "ự", "ư", "ỳ", "ý", "ỷ", "ỹ", "ỵ",
                                                 "À", "Á", "Ả", "Ã", "Ạ", "Ầ", "Ấ", "Ẩ", "Ẫ", "Ậ", "Â",
                                                 "Ằ", "Ắ", "Ẳ", "Ẵ", "Ặ", "Ă", "È", "É", "Ẻ", "Ẽ", "Ẹ", "Ề", "Ế", "Ể",
                                                 "Ễ", "Ệ", "Ê", "Đ", "Ì", "Í", "Ỉ", "Ĩ ", "Ị ", "Ò", "Ó", "Ỏ", "Õ", "Ọ", "Ồ",
                                                 "Ố", "Ổ", "Ỗ", "Ộ", "Ô", "Ờ", "Ớ", "Ở", "Ỡ", "Ợ", "Ơ", "Ù", "Ú", "Ủ",
                                                 "Ũ", "Ụ", "Ừ", "Ứ", "Ử", "Ữ", "Ự", "Ư", "Ỳ", "Ý", "Ỷ", "Ỹ", "Ỵ"};

                for (int i = 0; i < arUni.Length; i++)
                    retVal = retVal.Replace(arUni[i], arKD[i]);
                while (retVal.Contains("  "))
                    retVal = retVal.Replace("  ", " ");

                retVal = retVal.Replace("_", "");
            }
            catch
            {
            }
            return retVal;
        }

        public static bool ValidPhoneNumer(string phoneNumber, string lengthAndPrefixNumber, out string newPhoneNumer)
        {
            Regex rx = new Regex("^[0-9]+$");

            if (!rx.IsMatch(phoneNumber))
            {
                newPhoneNumer = string.Empty;
                return false;
            }

            phoneNumber = new string(phoneNumber.Where(char.IsDigit).ToArray());

            if (string.IsNullOrEmpty(phoneNumber))
            {
                newPhoneNumer = string.Empty;
                return false;
            }

            var lstlengthAndPrefixNumberStr = lengthAndPrefixNumber.Split(';');

            var lstValid = lstlengthAndPrefixNumberStr.Select(item => item.Split('-')).
                ToDictionary(lf => int.Parse(lf[0]), lf => lf[1].Split(',').ToList());

            if (lstValid.Where(valid => phoneNumber.Length == valid.Key).
                Any(valid => valid.Value.Any(pre => phoneNumber.IndexOf(pre, StringComparison.Ordinal) == 0)))
            {
                newPhoneNumer = phoneNumber;
                return true;
            }
            newPhoneNumer = string.Empty;
            return false;
        }

        public static bool ValidPhoneNumer(string phoneNumber, string lengthAndPrefixPhoneNumber = "10-09,086,088,089,020,032,033,034,035,036,037,038,039,070,079,077,076,078,083,084,085,081,082,056,058,059")
        {
            Regex rx = new Regex("^[0-9]+$");

            if (!rx.IsMatch(phoneNumber))
            {
                return false;
            }

            phoneNumber = new string(phoneNumber.Where(char.IsDigit).ToArray());

            if (string.IsNullOrEmpty(phoneNumber))
            {
                return false;
            }

            var lstlengthAndPrefixNumberStr = lengthAndPrefixPhoneNumber.Split(';');

            var lstValid = lstlengthAndPrefixNumberStr.Select(item => item.Split('-')).
                ToDictionary(lf => int.Parse(lf[0]), lf => lf[1].Split(',').ToList());

            if (lstValid.Where(valid => phoneNumber.Length == valid.Key).
                Any(valid => valid.Value.Any(pre => phoneNumber.IndexOf(pre, StringComparison.Ordinal) == 0)))
            {
                return true;
            }

            return false;
        }

        private static char ConvertedVnChar(char x)
        {
            if ((x >= 'a' && x <= 'z') || (x >= '0' && x <= '9') || (x >= 'A' && x <= 'Z'))
            {
                return x;
            }
            String s = x.ToString();

            if ("àáạảãâầấậẩẫăắằặẳẵ".Contains(s)) return 'a';
            if ("èéẹẻẽêềếệểễ".Contains(s)) return 'e';
            if ("ìíịỉĩ".Contains(s)) return 'i';
            if ("đ".Contains(s)) return 'd';
            if ("òóọỏõôồốộổỗơờớợởỡ".Contains(s)) return 'o';
            if ("ùúụủũưừứựửữ".Contains(s)) return 'u';
            if ("ỳýỵỷỹ".Contains(s)) return 'y';
            if ("ÀÁẠẢÃÂẦẤẬẨẪĂẮẰẶẲẴ".Contains(s)) return 'A';
            if ("ÈÉẸẺẼÊỀẾỆỂỄ".Contains(s)) return 'E';
            if ("ÌÍỊỈĨ".Contains(s)) return 'I';
            if ("Đ".Contains(s)) return 'D';
            if ("ÒÓỌỎÕÔỒỐỘỔỖƠỜỚỢỞỠ".Contains(s)) return 'O';
            if ("ÙÚỤỦŨƯỪỨỰỬỮ".Contains(s)) return 'U';
            if ("ỲÝỴỶỸ".Contains(s)) return 'Y';
            if (x == '\t' || x == ' ') return '-';
            if (@"_&*?(){}[]\|/+:'"";,.-".Contains(s)) return '-';

            return '@';
        }

        #endregion Methods
    }
}