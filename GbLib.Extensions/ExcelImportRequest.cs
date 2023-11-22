using Microsoft.AspNetCore.Http;

namespace GbLib.Extensions
{
    /// <summary>
    /// In conclusion, there are several options for reading data from Excel in C#
    /// and the best solution depends on the specific requirements for the project
    /// whether it's using the Microsoft office interop libraries, the open-source
    /// library Epplus, or another third-party library, C# developer have a range
    /// of tools at their disposal to effciently read and word with excel data.
    /// </summary>
    public class ExcelImportRequest
    {
        public int WorkSheet { get; set; }
        public int StartRow { get; set; }
        public int PaddingBottom { get; set; }
        public List<string> HeaderNames { get; set; }
        public IFormFile File { get; set; }
    }

    public class ExcelImportRequestBuilder
    {
        private ExcelImportRequest objBuilder = new ExcelImportRequest();
        public ExcelImportRequest Build => objBuilder;

        public ExcelImportRequestBuilder SetStartRow(int startRow)
        {
            objBuilder.StartRow = startRow;
            return this;
        }

        public ExcelImportRequestBuilder SetWorkSheetIndex(int index)
        {
            objBuilder.WorkSheet = index;
            return this;
        }

        public ExcelImportRequestBuilder SetHeaderColumn(string headerNames)
        {
            string[] myArray = headerNames.Split(',');
            List<string> sortProperties = myArray.Select(x => x.Trim()).ToList();
            objBuilder.HeaderNames = sortProperties;
            return this;
        }

        public ExcelImportRequestBuilder SetFile(IFormFile file)
        {
            objBuilder.File = file;
            return this;
        }

        public ExcelImportRequestBuilder SetPaddingBottom(int pading)
        {
            objBuilder.PaddingBottom = pading;
            return this;
        }
    }
}