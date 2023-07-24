namespace Nobi.ExcelLib
{
    public class ExcelGridColumn
    {
        public List<ExcelColumnHeader> Header { get; set; }
        public List<ExcelColumnFooter> Footer { get; set; }
        public string ColumnName { get; set; }
        public int ColumnSpan { get; set; } = 1;
        public int Order { get; set; }
        public double Width { get; set; } = 8.43;
        public ExcelCellFormat BodyFormat { get; set; }

        public ExcelGridColumn(string columnName, int colSpan, int order)
        {
            ColumnName = columnName;
            ColumnSpan = colSpan;
            Order = order;
        }
        public ExcelGridColumn(List<ExcelColumnHeader> header, List<ExcelColumnFooter> footer, string columnName, int order, int colSpan)
        {
            Header = header;
            Footer = footer;
            ColumnName = columnName;
            ColumnSpan = colSpan;
            Order = order;
        }
        public ExcelGridColumn()
        {

        }
        public ExcelGridColumn SetFooter(List<ExcelColumnFooter> gridFooter)
        {
            Footer = gridFooter;
            return this;
        }
        public ExcelGridColumn SetHeader(List<ExcelColumnHeader> gridHeader)
        {
            Header = gridHeader;
            return this;
        }
    }
}
