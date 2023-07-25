namespace GbLib.ExcelLib
{
    public interface IExcelImageSection : IExcelSection
    {
        ExcelImageSection SetImage(List<ImageProperties> list);
    }
}
