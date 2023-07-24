using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobi.ExcelLib
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
