namespace Nobi.ExcelLib
{
    public class ExcelGridSection : ExcelSection, IExcelGridSection
    {
        public IList<ExcelGridColumn> Columns { get; set; }
        public double RowHeight { get; set; } = 20;
        public ExcelGridSection(IList<ExcelGridColumn> columns)
        {
            Columns = columns;
        }
        public ExcelGridSection()
        {
            Columns = new List<ExcelGridColumn>();
        }

        public IExcelGridSection SetColumns(List<ExcelGridColumn> listColumns)
        {
            Columns = listColumns;
            return this;
        }
    }
}
