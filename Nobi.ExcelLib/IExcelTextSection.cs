namespace Nobi.ExcelLib
{
    public interface IExcelTextSection : IExcelSection
    {
        IExcelTextSection SetColumnSpan(int colspan);
        IExcelTextSection SetDataFormat(ExcelCellFormat format);
    }
}
