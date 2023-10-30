using System.ComponentModel;
using System.Data;
using System.Text;
using System.Text.Json;
using System.Xml;

namespace GbLib.Extensions
{
    public static class Utils
    {
        #region Constants

        private const string temp = "-----------------------------------------------------------------------";

        #endregion Constants

        #region Fields

        private static readonly string[] VietnameseSigns = new string[]
        {
            "aAeEoOuUiIdDyY",

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

        public static double Tolerance = 1e-15;

        private static char[] tcvnchars = {
            'µ', '¸', '¶', '·', '¹',
            '¨', '»', '¾', '¼', '½', 'Æ',
            '©', 'Ç', 'Ê', 'È', 'É', 'Ë',
            '®', 'Ì', 'Ð', 'Î', 'Ï', 'Ñ',
            'ª', 'Ò', 'Õ', 'Ó', 'Ô', 'Ö',
            '×', 'Ý', 'Ø', 'Ü', 'Þ',
            'ß', 'ã', 'á', 'â', 'ä',
            '«', 'å', 'è', 'æ', 'ç', 'é',
            '¬', 'ê', 'í', 'ë', 'ì', 'î',
            'ï', 'ó', 'ñ', 'ò', 'ô',
            '­', 'õ', 'ø', 'ö', '÷', 'ù',
            'ú', 'ý', 'û', 'ü', 'þ',
            '¡', '¢', '§', '£', '¤', '¥', '¦'
        };

        private static char[] unichars = {
            'à', 'á', 'ả', 'ã', 'ạ',
            'ă', 'ằ', 'ắ', 'ẳ', 'ẵ', 'ặ',
            'â', 'ầ', 'ấ', 'ẩ', 'ẫ', 'ậ',
            'đ', 'è', 'é', 'ẻ', 'ẽ', 'ẹ',
            'ê', 'ề', 'ế', 'ể', 'ễ', 'ệ',
            'ì', 'í', 'ỉ', 'ĩ', 'ị',
            'ò', 'ó', 'ỏ', 'õ', 'ọ',
            'ô', 'ồ', 'ố', 'ổ', 'ỗ', 'ộ',
            'ơ', 'ờ', 'ớ', 'ở', 'ỡ', 'ợ',
            'ù', 'ú', 'ủ', 'ũ', 'ụ',
            'ư', 'ừ', 'ứ', 'ử', 'ữ', 'ự',
            'ỳ', 'ý', 'ỷ', 'ỹ', 'ỵ',
            'Ă', 'Â', 'Đ', 'Ê', 'Ô', 'Ơ', 'Ư'
        };

        #endregion Fields

        #region Methods

        public static int CompareDate(this DateTime compare, DateTime obj, bool chekHours = false)
        {
            if (compare.Year > obj.Year)
                return 1;
            if (compare.Year < obj.Year)
                return -1;
            if (compare.Month > obj.Month)
                return 1;
            if (compare.Month < obj.Month)
                return -1;
            if (compare.Day > obj.Day)
                return 1;
            if (compare.Day < obj.Day)
                return -1;
            if (chekHours)
            {
                if (compare.Hour > obj.Hour)
                    return 1;
                if (compare.Hour < obj.Hour)
                    return -1;
                if (compare.Minute > obj.Minute)
                    return 1;
                if (compare.Minute < obj.Minute)
                    return -1;
                if (compare.Second > obj.Second)
                    return 1;
                if (compare.Second < obj.Second)
                    return -1;
            }
            return 0;
        }

        public static DataTable ConvertToDataTable<T>(IList<T> data, bool FHead = false)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties)

                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            if (FHead)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.DisplayName ?? row[prop.Name];
            }

            foreach (T item in data)
            {
                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)

                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;

                table.Rows.Add(row);
            }

            return table;
        }

        public static List<T> DeepClone<T>(List<T> obj)
        {
            List<T> objResult = null;
            string ms = JsonSerializer.Serialize(obj);
            objResult = JsonSerializer.Deserialize<List<T>>(ms);
            return objResult;
        }

        public static string formatNumber(object money, string format = Enums.FormatModel.Currency)
        {
            if (money.ToString().Equals("0") || long.Parse(money.ToString().Replace(",", "").Replace(".", "")) == 0)
                return format.Equals(Enums.FormatModel.Currency) ? "0 đ" : "0";
            return String.Format(format, money);
        }

        public static string GetFriendlyTitle(string title, bool remapToAscii = false, int maxlength = 80)
        {
            if (title == null)
            {
                return string.Empty;
            }

            int length = title.Length;
            bool prevdash = false;
            StringBuilder stringBuilder = new StringBuilder(length);
            char c;

            for (int i = 0; i < length; ++i)
            {
                c = title[i];
                if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
                {
                    stringBuilder.Append(c);
                    prevdash = false;
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    stringBuilder.Append((char)(c | 32));
                    prevdash = false;
                }
                else if ((c == ' ') || (c == ',') || (c == '.') || (c == '/') ||
                    (c == '\\') || (c == '-') || (c == '_') || (c == '='))
                {
                    if (!prevdash && (stringBuilder.Length > 0))
                    {
                        stringBuilder.Append(' ');
                        prevdash = true;
                    }
                }
                else if (c >= 128)
                {
                    int previousLength = stringBuilder.Length;

                    if (remapToAscii)
                    {
                        stringBuilder.Append(RemapInternationalCharToAscii(c));
                    }
                    else
                    {
                        stringBuilder.Append(c);
                    }

                    if (previousLength != stringBuilder.Length)
                    {
                        prevdash = false;
                    }
                }

                if (i == maxlength)
                {
                    break;
                }
            }

            if (prevdash)
            {
                return stringBuilder.ToString().Substring(0, stringBuilder.Length - 1);
            }
            else
            {
                return stringBuilder.ToString();
            }
        }

        public static string GetSpaceByLevel(int level)
        {
            if (level <= 0)
                return string.Empty;
            return temp.Substring(0, level);
        }

        public static decimal Max(params decimal[] numbers) => numbers.Max();

        public static double Max(params double[] numbers) => numbers.Max();

        public static decimal Min(params decimal[] numbers) => numbers.Min();

        public static double Min(params double[] numbers) => numbers.Min();

        public static string PadCenter(this string s, int width, char c)
        {
            if (s == null || width <= s.Length) return s;

            int padding = width - s.Length;
            return s.PadLeft(s.Length + padding / 2, c).PadRight(width, c);
        }

        public static void ReadXml(string pathFile)
        {
            XmlTextReader reader = new XmlTextReader(pathFile);
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        break;

                    case XmlNodeType.Text:
                        break;

                    case XmlNodeType.EndElement:
                        break;
                }
            }
        }

        public static string RemoveSign4VietnameseString(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)

                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }

            return str;
        }

        public static string ReplaceFirst(this string text, string oldStr, string newStr)
        {
            int pos = text.IndexOf(oldStr);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + newStr + text.Substring(pos + oldStr.Length);
        }

        public static bool stringEquals(string a, string b)
        {
            if (string.IsNullOrEmpty(a) && string.IsNullOrEmpty(b))
                return true;
            if (string.IsNullOrEmpty(a))
                return false;
            if (string.IsNullOrEmpty(b))
                return false;
            return string.Equals(a, b);
        }

        public static string ToStringSearch(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            return RemoveSign4VietnameseString(str.ToLower());
        }

        private static string RemapInternationalCharToAscii(char character)
        {
            string s = character.ToString().ToLowerInvariant();
            if ("àåáâäãåąāáàạảãâấầậẩẫăắằặẳẵ".Contains(s))
            {
                return "a";
            }
            else if ("èéêëęéèẹẻẽêếềệểễ".Contains(s))
            {
                return "e";
            }
            else if ("ìíîïıíìịỉĩ".Contains(s))
            {
                return "i";
            }
            else if ("òóôõöøőðóòọỏõôốồộổỗơớờợởỡ".Contains(s))
            {
                return "o";
            }
            else if ("ùúûüŭůúùụủũưứừựửữ".Contains(s))
            {
                return "u";
            }
            else if ("çćčĉ".Contains(s))
            {
                return "c";
            }
            else if ("żźž".Contains(s))
            {
                return "z";
            }
            else if ("śşšŝ".Contains(s))
            {
                return "s";
            }
            else if ("ñń".Contains(s))
            {
                return "n";
            }
            else if ("ýÿýỳỵỷỹ".Contains(s))
            {
                return "y";
            }
            else if ("ğĝ".Contains(s))
            {
                return "g";
            }
            else if (s.Equals('ř'))
            {
                return "r";
            }
            else if (s.Equals('ł'))
            {
                return "l";
            }
            else if ("đđ".Contains(s))
            {
                return "d";
            }
            else if (s.Equals('ß'))
            {
                return "ss";
            }
            else if (s.Equals('Þ'))
            {
                return "th";
            }
            else if (s.Equals('ĥ'))
            {
                return "h";
            }
            else if (s.Equals('ĵ'))
            {
                return "j";
            }
            else
            {
                return string.Empty;
            }
        }


        /// 
        /// Chuyển phần nguyên của số thành chữ
        /// 
        /// Số double cần chuyển thành chữ
        /// Chuỗi kết quả chuyển từ số
        public static string NumberToVietnameseText(double inputNumber, bool suffix = true)
        {
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
            bool isNegative = false;

            // -12345678.3445435 => "-12345678"
            string sNumber = inputNumber.ToString("#");
            double number = Convert.ToDouble(sNumber);
            if (number < 0)
            {
                number = -number;
                sNumber = number.ToString();
                isNegative = true;
            }


            int ones, tens, hundreds;

            int positionDigit = sNumber.Length;   // last -> first

            string result = " ";


            if (positionDigit == 0)
                result = unitNumbers[0] + result;
            else
            {
                // 0:       ###
                // 1: nghìn ###,###
                // 2: triệu ###,###,###
                // 3: tỷ    ###,###,###,###
                int placeValue = 0;

                while (positionDigit > 0)
                {
                    // Check last 3 digits remain ### (hundreds tens ones)
                    tens = hundreds = -1;
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }

                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                        result = placeValues[placeValue] + result;

                    placeValue++;
                    if (placeValue > 3) placeValue = 1;

                    if ((ones == 1) && (tens > 1))
                        result = "một " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))
                            result = "lăm " + result;
                        else if (ones > 0)
                            result = unitNumbers[ones] + " " + result;
                    }
                    if (tens < 0)
                        break;
                    else
                    {
                        if ((tens == 0) && (ones > 0)) result = "lẻ " + result;
                        if (tens == 1) result = "mười " + result;
                        if (tens > 1) result = unitNumbers[tens] + " mươi " + result;
                    }
                    if (hundreds < 0) break;
                    else
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " trăm " + result;
                    }
                    result = " " + result;
                }
            }
            result = result.Trim();
            if (isNegative) result = "Âm " + result;
            return result + (suffix ? " đồng chẵn" : "");
        }
        #endregion Methods
    }
}
