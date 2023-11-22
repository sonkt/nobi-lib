namespace GbLib.ExcelLib
{
    public interface IExcelListSection : IExcelSection
    {
        IExcelListSection SetColumnSpan(int colspan);

        IExcelListSection SetDataFormat(ExcelCellFormat format);
    }
}