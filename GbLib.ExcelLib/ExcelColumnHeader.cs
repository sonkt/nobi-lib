namespace GbLib.ExcelLib
{
    public class ExcelColumnHeader
    {
        public string Title { get; set; }
        public ExcelCellFormat Format { get; set; }
        public int ColumnSpan { get; set; }
        public int RowSpan { get; set; }

        public ExcelColumnHeader(string title, ExcelCellFormat format)
        {
            Title = title;
            Format = format;
        }

        public ExcelColumnHeader()
        {
            Format = new ExcelCellFormat();
        }
    }
}