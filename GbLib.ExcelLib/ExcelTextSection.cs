namespace GbLib.ExcelLib
{
    public class ExcelTextSection : ExcelSection, IExcelTextSection
    {
        public int ColumnSpan { get; set; }
        public ExcelCellFormat DataFormat { get; set; }
        public IExcelTextSection SetColumnSpan(int colspan)
        {
            ColumnSpan = colspan;
            return this;
        }

        public IExcelTextSection SetDataFormat(ExcelCellFormat format)
        {
            DataFormat = format;
            return this;
        }
    }
}
