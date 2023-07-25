namespace GbLib.ExcelLib
{
    public class ExcelColumnFooter
    {
        public string Content { get; set; }
        public ExcelCellFormat Format { get; set; }
        public int ColumnSpan { get; set; } = 1;
        public int RowSpan { get; set; } = 1;
        public ExcelColumnFooter(string content, ExcelCellFormat format)
        {
            Content = content;
            Format = format;
        }
        public ExcelColumnFooter()
        {
            Format = new ExcelCellFormat();
        }
    }
}
