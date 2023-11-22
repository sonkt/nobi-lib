namespace GbLib.Extensions
{
    public class Column
    {
        public string PropertyName { get; set; }
        public string XmlName { get; set; }
        public bool IsDateTime { get; set; }
        public bool IsDataMismatch { get; set; }
        public IDataMismatch Func { get; set; }
    }

    public interface IDataMismatch
    {
        string HandleDataMismatch(string value);
    }

    public class HandleRegisterType : IDataMismatch
    {
        public string HandleDataMismatch(string value)
        {
            if (value.Contains("/") || value.Contains("-"))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
    }

    /// <summary>
    /// Convert 'HANG_GPLX_CU' from xml file which must execute by server
    /// ex: input 'A1|B1', output B1
    /// hander injected by out side
    /// </summary>
    public class HandleOldRank : IDataMismatch
    {
        public string HandleDataMismatch(string value)
        {
            try
            {
                if (value.Contains("|"))
                {
                    string[] values = value.Split('|');
                    return values[1];
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"HANG_GPLX_CU : {value}, chưa xử được dữ liệu này, system-message : {ex.Message}");
            }
            return value;
        }
    }

    /// <summary>
    /// Read gender and execute in file xml
    /// </summary>
    public class HandleGender : IDataMismatch
    {
        public string HandleDataMismatch(string value)
        {
            try
            {
                string gender = value.ToLower();
                if (gender == "m") return "0";
                if (gender == "f") return "1";
                return null;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"{nameof(HandleGender)} : can't convert 'gender' form string-type to int-type, error: {ex.Message}");
                throw;
            }
        }
    }
}