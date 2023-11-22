namespace GbLib.ExcelLib
{
    public class ExcelListSection : ExcelSection, IExcelListSection
    {
        public int ColumnSpan { get; set; }
        public ExcelCellFormat DataFormat { get; set; }

        public IExcelListSection SetColumnSpan(int colspan)
        {
            ColumnSpan = colspan;
            return this;
        }

        public IExcelListSection SetDataFormat(ExcelCellFormat format)
        {
            DataFormat = format;
            return this;
        }
    }
}