namespace GbLib.ExcelLib
{
    public class ExcelImageSection : ExcelSection, IExcelImageSection
    {
        public IList<ImageProperties> Images { get; set; }

        public ExcelImageSection SetImage(List<ImageProperties> list)
        {
            Images = list;
            return this;
        }
    }
}