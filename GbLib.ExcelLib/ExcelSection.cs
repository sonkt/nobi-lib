using OfficeOpenXml.Style;
using System.Drawing;

namespace GbLib.ExcelLib
{
    public abstract class ExcelSection : IExcelSection
    {
        public int StartColumnOfContent { get; set; }
        public int StartRowOfContent { get; set; }
        public IList<object> Data { get; set; }
        public int MarginTop { get; set; }
        public ExcelBorderStyle BorderStyle { get; set; }
        public Color BorderColor { get; set; }
    }
}