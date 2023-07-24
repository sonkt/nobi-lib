using OfficeOpenXml.Style;
using System.Drawing;

namespace Nobi.ExcelLib
{
    public class ExcelCellFormat
    {
        public int FontSize { get; set; } = 11;
        public string FontName { get; set; } = "Times New Roman";
        public bool IsBold { get; set; } = false;
        public bool IsItalic { get; set; } = false;
        public bool IsUnderline { get; set; } = false;
        public bool IsWrapText { get; set; } = false;
        public ExcelHorizontalAlignment TextAlignment { get; set; } = ExcelHorizontalAlignment.Left;
        public ExcelVerticalAlignment TextVerticalAlignment { get; set; } = ExcelVerticalAlignment.Center;
        public ExcelFillStyle FillStyle { get; set; } = ExcelFillStyle.Solid;
        public int TextRotation { get; set; } = 0;
        public Color TextColor { get; set; } = Color.Black;
        public Color BorderColor { get; set; } = Color.Gray;
        public Color BackgroundColor { get; set; } = Color.White;
        public string DataFormat { get; set; } = "General";
        public double RowHeight { get; set; } = 15.0;
    }
}
