namespace GbLib.ExcelLib
{
    public interface IExcelGridSection : IExcelSection
    {
        IExcelGridSection SetColumns(List<ExcelGridColumn> listColumns);
    }
}